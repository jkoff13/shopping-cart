using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart.Helpers
{
    public class ReceiptHelper
    {
        public static string Generate(ShoppingCartModel shoppingCart)
        {
            var sb = new StringBuilder();
            sb.Append(@"<style>
                        .invoice {
                          box-shadow: 0 0 1in -0.25in rgba(0, 0, 0, 0.5);
                          padding:2mm;
                          margin: 0 auto;
                          width: 84mm;
                          background: #FFF;
                        }                          
                        p{
                          font-size: 2.7em;
                          color: #666;
                          line-height: 1.2em;
                        }                          
                        .info{
                          display: block;
                          margin-left: 0;
                        }
                        .title{
                          float: right;
                        }
                        .title p{text-align: right;} 
                        table{
                          width: 100%;
                          border-collapse: collapse;
                        }
                        .tabletitle{
                          font-size: .5em;
                          background: #EEE;
                        }
                        .item{width: 24mm;}
                        .itemtext{font-size: .8em;}
                    </style>");

            sb.Append(@"<div class='invoice'><div class='bot'><div class='table'><table>");
            sb.Append(@"<tr class='tabletitle'><td><h2>Item</h2></td><td><h2>Qty</h2></td><td><h2>Sub Total</h2></td></tr>");

            foreach (var product in shoppingCart.Products)
            {
              sb.Append($@"<tr class='service'>
                            <td class='tableitem'><p class='itemtext'>{product.Name}</p></td>
                            <td class='tableitem'><p class='itemtext'>{product.Count}</p></td>
                            <td class='tableitem'><p class='itemtext'>${product.TotalAmount}</p></td>
                          </tr>");
            }

            sb.Append($@"<tr class='tabletitle'>
                                    <td></td>
                                        <td><h2>Total</h2></td>
                                        <td><h2>${shoppingCart.GetTotalAmount()}</h2></td>
                                    </tr>");
            sb.Append(@"</table></div></div></div>");
            return sb.ToString();
        }
    }
}