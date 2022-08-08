using Microsoft.AspNetCore.Components;
using QLSV.Model;
using QLSVWasm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVWasm.Pages
{
    public partial class SinhVien
    {
        [Inject] private ISinhVienApiClient SinhVienApiClient { get; set; }

        private List<SinhVienDTO> SinhViens;
        protected override async Task OnInitializedAsync()
        {
            SinhViens = await SinhVienApiClient.GetSinhViens();
        }
        private async void Delete(Guid id)
        {
            
            SinhVienApiClient.Delete(id);
            SinhViens = await SinhVienApiClient.GetSinhViens();
        }
    }
}
