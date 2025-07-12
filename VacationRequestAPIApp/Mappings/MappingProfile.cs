using AutoMapper;
using VacationRequestAPIApp.DTOs.Department;
using VacationRequestAPIApp.DTOs.OfficialHolidays;
using VacationRequestAPIApp.DTOs.VacationRequests;
using VacationRequestAPIApp.Models;

namespace VacationRequestAPIApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DepartmentCreateDto,Department>().AfterMap((src,dest)=>
            {
               dest.departmentName = src.Name;

            });
            CreateMap<Department,DepartmentReadDto>().AfterMap((src, dest) =>
            {
                dest.Name = src.departmentName;
            });
            CreateMap<DepartmentUpdateDto, Department>().AfterMap((src, dest) =>
            {
                dest.departmentName = src.Name;
            });
            CreateMap<OfficialHolidayCreateDto, OfficialHoliday>().AfterMap((src, dest) =>
            {
                dest.Date = src.HolidayDate;
                dest.holidayTitle = src.HolidayName;
            });
            CreateMap<OfficialHoliday, OfficialHolidayReadDto>().AfterMap((src, dest) =>
            {
                dest.HolidayDate = src.Date;
                dest.HolidayName = src.holidayTitle;
            });
            CreateMap<OfficialHolidayUpdateDto, OfficialHoliday>().AfterMap((src, dest) =>
            {
                dest.Date = src.HolidayDate;
                dest.holidayTitle = src.HolidayName;
            });
            CreateMap<VacationRequestCreateDto, VacationRequest>().AfterMap((src, dest) =>
            {
                dest.SubmissionDate = DateTime.Now;
                dest.EmployeeName = src.NameOfEmployee;
                dest.Title = src.TitleVacationRequest;
                dest.DepartmentId = src.DepartmentOfEmployeeId;
                dest.VacationFrom = src.VacationDateFrom;
                dest.VacationTo = src.VacationDateTo;
                dest.Notes=src.Notes;
            });
            CreateMap<VacationRequest, VacationRequestReadDto>().AfterMap((src, dest) =>
            {
                dest.VacationId = src.Id;
                dest.SubmissionDate = src.SubmissionDate;
                dest.NameOfEmployee = src.EmployeeName;
                dest.TitleVacationRequest = src.Title;
                dest.DepartmentName = src.Department.departmentName;
                dest.VacationDateFrom = src.VacationFrom;
                dest.VacationDateTo = src.VacationTo;
                dest.ReturningDate = src.ReturningDate;
                dest.TotalDays = src.TotalDays;
                dest.Notes = src.Notes;
            });
        }
    }
}
