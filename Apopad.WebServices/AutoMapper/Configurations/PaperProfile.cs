using Apopad.Domain.Model;
using Apopad.ViewModels.Paper;
using AutoMapper;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Apopad.WebServices.AutoMapper.Configurations
{
    public class PaperProfile : Profile
    {
        public PaperProfile()
        {
            CreateMap<string, int?>().ConvertUsing<IntTypeConverter>();
            CreateMap<string, bool?>().ConvertUsing<BoolTypeConverter>();

            CreateMap<PaperDto4E, Paper>()
                .ForMember(dest => dest.PublicationDate, opt =>
                {
                    opt.ResolveUsing<DateTimeResolver>();
                });
        }
    }

    public class BoolTypeConverter : ITypeConverter<string, bool?>
    {
        public bool? Convert(string source, bool? destination, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source))
            {
                return true;
            }

            return false;
        }
    }

    public class IntTypeConverter : ITypeConverter<string, int?>
    {
        public int? Convert(string source, int? destination, ResolutionContext context)
        {
            Regex re = new Regex(@"^\d+$"); //匹配数字字符串
            if (!string.IsNullOrWhiteSpace(source) && re.IsMatch(source))
            {
                return int.Parse(source);
            }

            return null;
        }
    }

    public class DateTimeResolver : IValueResolver<PaperDto4E, Paper, DateTime?>
    {
        public DateTime? Resolve(PaperDto4E source, Paper destination, DateTime? destMember, ResolutionContext context)
        {
            string sDate = source.PublicationDate.Trim();
            string sYear = source.Year.Trim();
            DateTime? PublishDate = null;
            string[] expectedFormats = { "yyyy/M/d H:mm:ss", "yyyy", "yyyy/M/d" };
            string[] months = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
            Regex re = new Regex(@"^([A-Z][-]?)+$"); //匹配字母字符串

            if (sDate != "" && re.IsMatch(sDate) && sYear != "")    //发表日期为月份英文简写
            {
                PublishDate = DateTime.ParseExact(sYear, expectedFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
                for (int m = 0; m < 12; m++)
                {
                    if (sDate.Contains(months[m]))
                    {
                        PublishDate = PublishDate.Value.AddMonths(m);
                        break;
                    }
                }
            }
            if (PublishDate == null && sDate != "" && sYear != "")  //发表日期为yyyy/m/d这种形式
            {
                DateTime dt = DateTime.ParseExact(sDate, expectedFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
                PublishDate = new DateTime(int.Parse(sYear), dt.Month, dt.Day);
            }
            if (PublishDate == null && sYear != "") //只有发表年份
            {
                PublishDate = DateTime.ParseExact(sYear, expectedFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
            }

            return PublishDate;
        }
    }
}