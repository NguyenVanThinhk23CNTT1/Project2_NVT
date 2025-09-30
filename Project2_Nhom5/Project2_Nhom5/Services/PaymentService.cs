using Microsoft.EntityFrameworkCore;
using Project2_Nhom5.Models;

namespace Project2_Nhom5.Services
{
    public class PaymentService
    {
        private readonly Project2_Nhom5Context _context;

        public PaymentService(Project2_Nhom5Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Tạo thanh toán an toàn với triggers
        /// </summary>
        /// <param name="payment">Thông tin thanh toán</param>
        /// <returns></returns>
        public async Task<bool> CreatePaymentAsync(Payment payment)
        {
            try
            {
                // Kiểm tra xem vé đã có thanh toán chưa
                var existingPayment = await _context.Payments
                    .FirstOrDefaultAsync(p => p.TicketId == payment.TicketId);
                
                if (existingPayment != null)
                {
                    return false; // Vé đã có thanh toán
                }

                // Sử dụng raw SQL để tránh xung đột với triggers
                var sql = @"
                    INSERT INTO [dbo].[ThanhToan] ([MaVe], [SoTien], [PhuongThucThanhToan], [NgayThanhToan], [MaGiamGia])
                    VALUES (@ticketId, @amount, @paymentMethod, @paymentDate, @discountId)";

                var parameters = new[]
                {
                    new Microsoft.Data.SqlClient.SqlParameter("@ticketId", payment.TicketId),
                    new Microsoft.Data.SqlClient.SqlParameter("@amount", payment.Amount),
                    new Microsoft.Data.SqlClient.SqlParameter("@paymentMethod", payment.PaymentMethod ?? (object)DBNull.Value),
                    new Microsoft.Data.SqlClient.SqlParameter("@paymentDate", payment.PaymentDate ?? DateTime.Now),
                    new Microsoft.Data.SqlClient.SqlParameter("@discountId", payment.DiscountId ?? (object)DBNull.Value)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, parameters);

                // Cập nhật trạng thái vé thành 'DaThanhToan'
                var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == payment.TicketId);
                if (ticket != null)
                {
                    ticket.Status = "DaThanhToan";
                    _context.Tickets.Update(ticket);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy thông tin thanh toán với đầy đủ thông tin liên quan
        /// </summary>
        /// <param name="paymentId">ID thanh toán</param>
        /// <returns></returns>
        public async Task<Payment?> GetPaymentWithDetailsAsync(int paymentId)
        {
            return await _context.Payments
                .Include(p => p.Ticket)
                .ThenInclude(t => t.User)
                .Include(p => p.Ticket)
                .ThenInclude(t => t.Showtime)
                .ThenInclude(s => s.Movie)
                .Include(p => p.Ticket)
                .ThenInclude(t => t.Showtime)
                .ThenInclude(s => s.Theater)
                .Include(p => p.Discount)
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
        }

        /// <summary>
        /// Lấy danh sách thanh toán với bộ lọc
        /// </summary>
        /// <param name="search">Từ khóa tìm kiếm</param>
        /// <param name="paymentMethod">Phương thức thanh toán</param>
        /// <param name="status">Trạng thái vé</param>
        /// <param name="startDate">Ngày bắt đầu</param>
        /// <param name="endDate">Ngày kết thúc</param>
        /// <param name="page">Trang</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <returns></returns>
        public async Task<(List<Payment> Payments, int TotalCount)> GetPaymentsAsync(
            string? search = null,
            string? paymentMethod = null,
            string? status = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int page = 1,
            int pageSize = 10)
        {
            var query = _context.Payments
                .Include(p => p.Ticket)
                .ThenInclude(t => t.User)
                .Include(p => p.Ticket)
                .ThenInclude(t => t.Showtime)
                .ThenInclude(s => s.Movie)
                .Include(p => p.Discount)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => 
                    p.PaymentId.ToString().Contains(search) ||
                    p.Ticket.TicketId.ToString().Contains(search) ||
                    p.Ticket.User.Username.Contains(search) ||
                    p.Ticket.User.Email.Contains(search) ||
                    p.Ticket.Showtime.Movie.Title.Contains(search)
                );
            }

            if (!string.IsNullOrEmpty(paymentMethod))
            {
                query = query.Where(p => p.PaymentMethod == paymentMethod);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(p => p.Ticket.Status == status);
            }

            if (startDate.HasValue)
            {
                query = query.Where(p => p.PaymentDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                var endDateTime = endDate.Value.AddDays(1).AddSeconds(-1);
                query = query.Where(p => p.PaymentDate <= endDateTime);
            }

            var totalCount = await query.CountAsync();
            var payments = await query
                .OrderByDescending(p => p.PaymentDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (payments, totalCount);
        }
    }
}
