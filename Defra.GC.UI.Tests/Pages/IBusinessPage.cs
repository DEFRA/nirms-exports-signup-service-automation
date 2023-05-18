using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessPage
    {
        public void ClickonBusiness();

        public void EnterBusinessName();

        //public void ClickSignedOut();

        //public bool IsSignedOut();
    }
}