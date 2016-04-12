using System;
namespace Contracts
{
    public interface IIcing
    {
        string IcingDescription { get; set; }
        int IcingID { get; set; }
        string ImageUrl { get; set; }
        decimal Price { get; set; }
    }
}
