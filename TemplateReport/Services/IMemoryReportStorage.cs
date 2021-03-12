using System.Collections.Generic;
using Template.Dtos;
using TemplateReport.DTO;

namespace TemplateReport.Services
{
    public interface IMemoryReportStorage
    {
        void Add(Report report);
        IEnumerable<Report> Get();
        IEnumerable<InventUpdateDto> GetInvent();
    }
}