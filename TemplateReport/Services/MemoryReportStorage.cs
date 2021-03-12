using System.Collections.Generic;
using Template.Dtos;
using TemplateReport.DTO;

namespace TemplateReport.Services
{
    public class MemoryReportStorage : IMemoryReportStorage
    {
        private readonly IList<Report> reports = new List<Report>();
        private readonly IList<InventUpdateDto> Inventreports = new List<InventUpdateDto>();
        public void Add(Report report)
        {
            reports.Add(report);
        }

        public IEnumerable<Report> Get()
        {
            return reports;
        }

        public IEnumerable<InventUpdateDto> GetInvent()
        {
            return Inventreports;
        }
    }
}
