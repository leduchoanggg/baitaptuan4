using System;
using System.Collections.Generic;

namespace baitaptuan4.Models;

public partial class SinhVien
{
    public int MaSv { get; set; }

    public string HoTen { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Lop { get; set; }
}
