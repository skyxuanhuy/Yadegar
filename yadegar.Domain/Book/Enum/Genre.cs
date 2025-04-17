using System.ComponentModel.DataAnnotations;

namespace yadegar.Domain.Enum;

public enum Genre
{
    [Display(Name = "رمان عاشقانه")] Romance,

    [Display(Name = "داستان‌های تاریخی")] HistoricalFiction,

    [Display(Name = "داستان‌های جنایی و معمایی")]
    MysteryCrime,

    [Display(Name = "علمی تخیلی")] ScienceFiction,

    [Display(Name = "فانتزی")] Fantasy,

    [Display(Name = "زندگینامه و خاطرات")] BiographyMemoir,

    [Display(Name = "ادبیات کودک و نوجوان")]
    ChildrenYoungAdult,

    [Display(Name = "شعر")] Poetry,

    [Display(Name = "ادبیات کلاسیک")] ClassicLiterature,

    [Display(Name = "خودشناسی و روانشناسی")]
    SelfHelpPsychology,

    [Display(Name = "ادبیات زنان")] WomensLiterature,

    [Display(Name = "طنز")] Humor,

    [Display(Name = "ادبیات فلسفی")] PhilosophicalLiterature,

    [Display(Name = "ادبیات دینی و عرفانی")]
    ReligiousMysticalLiterature,

    [Display(Name = "ادبیات جنگ")] WarLiterature
}