using Microsoft.EntityFrameworkCore;
using Project2_Nhom5.Models;

namespace Project2_Nhom5.Services
{
    public class RevenueService
    {
        private readonly Project2_Nhom5Context _context;

        public RevenueService(Project2_Nhom5Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Cập nhật doanh thu cho một suất chiếu
        /// </summary>
        /// <param name="showtimeId">ID của suất chiếu</param>
        /// <returns></returns>
        public async Task UpdateRevenueForShowtimeAsync(int showtimeId)
        {
            // Use stored procedure to sync revenue data
            await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[sp_SyncRevenueData] @MaSuatChieu = {0}", showtimeId);
        }

        /// <summary>
        /// Lấy doanh thu thực tế cho một suất chiếu
        /// </summary>
        /// <param name="showtimeId">ID của suất chiếu</param>
        /// <returns></returns>
        public async Task<Revenue?> GetRevenueForShowtimeAsync(int showtimeId)
        {
            return await _context.Revenues
                .Include(r => r.Showtime)
                .ThenInclude(s => s.Movie)
                .Include(r => r.Showtime)
                .ThenInclude(s => s.Theater)
                .FirstOrDefaultAsync(r => r.ShowtimeId == showtimeId);
        }

        /// <summary>
        /// Lấy tất cả doanh thu với thông tin chi tiết
        /// </summary>
        /// <returns></returns>
        public async Task<List<Revenue>> GetAllRevenuesAsync()
        {
            return await _context.Revenues
                .Include(r => r.Showtime)
                .ThenInclude(s => s.Movie)
                .Include(r => r.Showtime)
                .ThenInclude(s => s.Theater)
                .OrderByDescending(r => r.CreatedDate)
                .ToListAsync();
        }

        /// <summary>
        /// Tính tổng doanh thu trong khoảng thời gian
        /// </summary>
        /// <param name="startDate">Ngày bắt đầu</param>
        /// <param name="endDate">Ngày kết thúc</param>
        /// <returns></returns>
        public async Task<decimal> GetTotalRevenueAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Revenues
                .Where(r => r.CreatedDate >= startDate && r.CreatedDate <= endDate)
                .SumAsync(r => r.ActualRevenue ?? 0);
        }

        /// <summary>
        /// Lấy thống kê doanh thu theo tháng
        /// </summary>
        /// <param name="year">Năm</param>
        /// <returns></returns>
        public async Task<List<object>> GetMonthlyRevenueStatsAsync(int year)
        {
            return await _context.Revenues
                .Where(r => r.CreatedDate.Year == year)
                .GroupBy(r => r.CreatedDate.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    TotalRevenue = g.Sum(r => r.ActualRevenue ?? 0),
                    TotalTickets = g.Sum(r => r.TicketsSold),
                    ShowtimeCount = g.Count()
                })
                .OrderBy(x => x.Month)
                .ToListAsync<object>();
        }
    }
}
