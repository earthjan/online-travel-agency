#pragma checksum "C:\Users\Earth Jan\Documents\Git\Repos\online-travel-agency\Pages\Travel\SecondProcess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e254da2e4b00da66894d80cd82953cc7e60a810"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Travel_SecondProcess), @"mvc.1.0.razor-page", @"/Pages/Travel/SecondProcess.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e254da2e4b00da66894d80cd82953cc7e60a810", @"/Pages/Travel/SecondProcess.cshtml")]
    public class Pages_Travel_SecondProcess : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<!-- 
        2.0 Main
            2.1 flight query <article>
            2.2 filter by <section>
            2.3 advertisement <section>
            2.4 flight results <section flexbox>
                2.4.1 load more <button flex shrink max>
    -->

<main class=""container-fluid mt-3"">
    <div class=""row row-cols-1 gy-4 row-cols-md-2 justify-content-lg-start"">
        <!-- First column -->
        <div class=""col col-lg-5"">
            <div class=""d-flex flex-column align-items-xl-center"">
                <!-- Booking -->
                <form class=""border rounded-3 w-px-md-350 bg-white py-3"" action=""#"" method=""GET"">
                    <div class=""container-fluid"">
                        <!-- Trip type, seat class, no. of passenger, & bags -->
                        <div class=""row row-cols-1 gy-2"">
                            <!-- Trip type -->
                            <div class=""col"">
                                <select class=""form-select border-0"" name=""trip_type"">
");
            WriteLiteral("                                    <option selected>Return</option>\r\n");
            WriteLiteral(@"                                </select>
                            </div>
                            <!-- Seat class -->
                            <div class=""col"">
                                <select class=""form-select border-0"" name=""cabin_class"">
");
            WriteLiteral("                                    <option selected>Economy</option>\r\n");
            WriteLiteral(@"                                </select>
                            </div>
                            <!-- No. of passenger, & bags -->
                            <div class=""col d-flex justify-content-center"">
                                <button class=""btn border border-secondary rounded-pill px-4 px-md-2""
                                    data-bs-toggle=""modal"" data-bs-target=""#exampleModal"" type=""button"">
                                    <span class=""my-icon-people fs-5""></span>
                                    <span class=""px-sm-1"" id=""passengerNumbersValue"">0</span>
                                    <!-- Uncertainly commented to migrate bag form controls to the 3rd process page passenger form. -->
                                    <!-- <span class=""my-icon-luggage fs-5""></span>
                                        <span class=""px-sm-1"" id=""bagsValue"">0</span> -->
                                </button>
                                <!-- No. of passenger -->
       ");
            WriteLiteral(@"                         <input type=""hidden"" name=""adult"" id=""adult"" value=""1"">
                                <input type=""hidden"" name=""child"" id=""child"" value=""0"">
                                <input type=""hidden"" name=""infant"" id=""infant"" value=""0"">
                                <!-- No. of bags -->
                                <!-- Uncertainly commented to migrate bag form controls to the 3rd process page passenger form. -->
                                <!-- <input type=""hidden"" name=""cabin_bag"" id=""cabin_bag"">
                                    <input type=""hidden"" name=""checked_bag"" id=""checked_bag""> -->
                            </div>
                        </div>

                        <!-- From & To locations -->
                        <div class=""row row-cols-1 gy-2 my-4"">
                            <!-- From location -->
                            <div class=""col"">
                                <div class=""input-group flex-nowrap justify-content-center"">
   ");
            WriteLiteral(@"                                 <label class=""input-group-text bg-white text-black-50"" for=""from"">From</label>
                                    <input class=""form-control"" type=""text"" name=""from"" id=""from"" required>
                                </div>
                            </div>
                            <!-- To location -->
                            <div class=""col"">
                                <div class=""input-group flex-nowrap justify-content-center"">
                                    <label class=""input-group-text bg-white text-black-50"" for=""to"">To</label>
                                    <input class=""form-control"" type=""text"" name=""to"" id=""to"" required>
                                </div>
                            </div>
                        </div>

                        <!-- Departure & Return schedules -->
                        <div class=""row row-cols-1 gy-2"">
                            <!-- Departure schedule -->
                            <");
            WriteLiteral(@"div class=""col"">
                                <div class=""input-group flex-nowrap justify-content-center"">
                                    <label class=""input-group-text bg-white text-black-50""
                                        for=""departure"">Departure</label>
                                    <input class=""form-control"" type=""datetime-local"" name=""departure"" id=""departure""
                                        required>
                                </div>
                            </div>
                            <!-- Return schedule -->
                            <div class=""col"">
                                <div class=""input-group flex-nowrap justify-content-center"">
                                    <label class=""input-group-text bg-white text-black-50"" for=""return"">Return</label>
                                    <input class=""form-control"" type=""datetime-local"" name=""return"" id=""return""
                                        required>
                    ");
            WriteLiteral(@"            </div>
                            </div>
                            <div class=""col d-flex justify-content-center"">
                                <button class=""btn border rounded bg-secondary-cs text-white"">
                                    Search Flight
                                </button>
                            </div>
                        </div>
                    </div>
                </form>
                <!-- Filter by -->
                <section class=""border border rounded-3 d-flex align-items-center mt-3 py-2 w-px-md-350"">
                    <div class=""container-fluid"">
                        <div class=""row row-cols-1"">
                            <!-- Title -->
                            <div class=""col"">
                                <div class=""fw-bold"">Filter by</div>
                            </div>
                            <!-- By price -->
                            <button class=""col btn d-flex justify-content-between border");
            WriteLiteral(@"-bottom"">
                                <span>Price</span>
                                <span class=""my-icon-more""></span>
                            </button>
                            <!-- By duration -->
                            <button class=""col btn d-flex justify-content-between border-bottom"">
                                <span>Duration</span>
                                <span class=""my-icon-more""></span>
                            </button>

                            <!-- By time-->
                            <button class=""col btn d-flex justify-content-between"">
                                <span>Time</span>
                                <span class=""my-icon-more""></span>
                            </button>
                        </div>
                    </div>
                </section>
                <!-- Advertisement -->
");
            WriteLiteral(@"            </div>
        </div>
        <!-- Second column -->
        <div class=""col col-lg-6"">
            <div class=""row row-cols-1 gy-3"">
                <!-- A flight result -->
                <!-- You can add more columns here for flight results. -->
");
#nullable restore
#line 156 "C:\Users\Earth Jan\Documents\Git\Repos\online-travel-agency\Pages\Travel\SecondProcess.cshtml"
                 for (int a = 0; a <= 3; a++)
                { 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col border rounded-3 py-3"">
                        <div class=""row row-cols-1 row-cols-lg-2"">
                            <!-- Flight Details -->
                            <div class=""col col-lg-9"">
                                <div class=""row row-cols-1"">
                                    <!-- Departure -->
                                    <div class=""col border-bottom"">
                                        <!-- Departure title -->
                                        <div class=""row justify-content-center pb-3"">
                                            <div class=""col-5 px-0"">
                                                <h6 class=""text-end"">Departure</h6>
                                            </div>
                                            <div class=""col-2 px-0 d-flex justify-content-center"">
                                                <h6>:</h6>
                                            </div>
                           ");
            WriteLiteral(@"                 <div class=""col-5 px-0 d-flex"">
                                                <h6 class=""align-self-stretch border border-dark rounded-pill px-1 my-0"">
                                                    2 stops</h6>
                                            </div>
                                        </div>
                                        <!-- Departure schedule -->
                                        <div class=""row row-cols-3"">
                                            <!-- From schedule -->
                                            <div class=""col d-flex justify-content-center"">
                                                <div class=""row row-cols-auto flex-column"">
                                                    <!-- Day and date -->
                                                    <div class=""col"">
                                                        <h6 class=""fw-bold mb-0"">Mon Jan 1</h6>
                                                 ");
            WriteLiteral(@"   </div>
                                                    <!-- Time -->
                                                    <div class=""col"">
                                                        <h6>9:00 PM</h6>
                                                    </div>
                                                    <!-- Location -->
                                                    <div class=""col py-3"">
                                                        <h6><span class=""fw-bold"">Manila</span> <span
                                                                class=""text-secondary"">MNL</span></h6>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- Flight duration -->
                                            <div class=""col d-flex flex-column justify-content-center align-items-center"">
                         ");
            WriteLiteral(@"                       <span class=""fs-1 my-icon-from_to_flight""></span>
                                                <span>27h 10m</span>
                                            </div>
                                            <!-- To schedule -->
                                            <div class=""col d-flex justify-content-center"">
                                                <div class=""row row-cols-auto flex-column"">
                                                    <!-- Day and date -->
                                                    <div class=""col"">
                                                        <h6 class=""fw-bold mb-0"">Mon Jan 1</h6>
                                                    </div>
                                                    <!-- Time -->
                                                    <div class=""col"">
                                                        <h6>9:00 PM</h6>
                                                    </div>
 ");
            WriteLiteral(@"                                                   <!-- Location -->
                                                    <div class=""col py-3"">
                                                        <h6><span class=""fw-bold"">Manila</span> <span
                                                                class=""text-secondary"">MNL</span></h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Arrival -->
                                    <div class=""col pt-3 border-bottom"">
                                        <!-- Arrival title -->
                                        <div class=""row justify-content-center pb-3"">
                                            <div class=""col-5 px-0"">
                                                <h6 class=""tex");
            WriteLiteral(@"t-end"">Arrival</h6>
                                            </div>
                                            <div class=""col-2 px-0 d-flex justify-content-center"">
                                                <h6>:</h6>
                                            </div>
                                            <div class=""col-5 px-0 d-flex"">
                                                <h6 class=""align-self-stretch border border-dark rounded-pill px-1 my-0"">
                                                    2 stops</h6>
                                            </div>
                                        </div>
                                        <!-- Arrival schedule -->
                                        <div class=""row row-cols-3 border-primary"">
                                            <!-- From schedule -->
                                            <div class=""col d-flex justify-content-center"">
                                                <div class=""");
            WriteLiteral(@"row row-cols-auto flex-column"">
                                                    <!-- Day and date -->
                                                    <div class=""col"">
                                                        <h6 class=""fw-bold mb-0"">Mon Jan 1</h6>
                                                    </div>
                                                    <!-- Time -->
                                                    <div class=""col"">
                                                        <h6>9:00 PM</h6>
                                                    </div>
                                                    <!-- Location -->
                                                    <div class=""col py-3"">
                                                        <h6><span class=""fw-bold"">Manila</span> <span
                                                                class=""text-secondary"">MNL</span></h6>
                                                    </div>
  ");
            WriteLiteral(@"                                              </div>
                                            </div>
                                            <!-- Flight duration -->
                                            <div class=""col d-flex flex-column justify-content-center align-items-center"">
                                                <span class=""fs-1 my-icon-from_to_flight""></span>
                                                <span>27h 10m</span>
                                            </div>
                                            <!-- To schedule -->
                                            <div class=""col d-flex justify-content-center"">
                                                <div class=""row row-cols-auto flex-column"">
                                                    <!-- Day and date -->
                                                    <div class=""col"">
                                                        <h6 class=""fw-bold mb-0"">Mon Jan 1</h6>
        ");
            WriteLiteral(@"                                            </div>
                                                    <!-- Time -->
                                                    <div class=""col"">
                                                        <h6>9:00 PM</h6>
                                                    </div>
                                                    <!-- Location -->
                                                    <div class=""col py-3"">
                                                        <h6><span class=""fw-bold"">Manila</span> <span
                                                                class=""text-secondary"">MNL</span></h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Seat class & details -->
                   ");
            WriteLiteral(@"                 <div class=""col pt-3"">
                                        <div class=""row row-cols-2"">
                                            <!-- Seat class -->
                                            <div class=""col d-flex align-items-center"">
                                                <h6 class=""border border-dark rounded-pill px-1 py-1 my-0"">Economy</h6>
                                            </div>
                                            <!-- Details -->
");
            WriteLiteral(@"                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Price and Book -->
                            <div class=""col col-lg-3"">
                                <div class=""row row-cols-2 h-100 row-cols-lg-1 flex-lg-column"">
                                    <!-- Price -->
                                    <div class=""col d-flex justify-content-center align-items-center flex-lg-grow-1"">
                                        <h6 class=""my-0"">₱44,444</h6>
                                    </div>
                                    <!-- To Book -->
                                    <form class=""col d-flex justify-content-center"" action=""#"" method=""GET"">
                                        <button class=""btn border rounded bg-secondary-cs text-white flex-fill""
                                            type=""submit"" value=""CHANGE THIS"">
       ");
            WriteLiteral(@"                                     Book
                                        </button>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 320 "C:\Users\Earth Jan\Documents\Git\Repos\online-travel-agency\Pages\Travel\SecondProcess.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>

    </div>
</main>

<!-- Modal for no. of passengers and bags -->
<div class=""modal fade"" tabindex=""-1"" id=""exampleModal"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">No. of passengers and bags</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <!-- Passengers -->
                <h6>Passengers</h6>
                <span class=""my-fs-small text-black-50"">The max number of each input is 5.</span>

                <hr>
                <!-- Types of passenger -->
                <!-- Adult -->
                <div class=""row justify-content-sm-center border py-2"">
                    <div class=""col-2 d-flex justify-content-center align-items-center"">
                        <span class=""my-icon-adul");
            WriteLiteral(@"t fs-5""></span>
                    </div>
                    <div class=""col-10 col-sm-2 d-flex justify-content-center"">
                        <div class=""row row-cols-1"">
                            <div class=""col text-center"">Adults</div>
                            <div class=""col text-center text-black-50 fw-light"">Over 11</div>
                        </div>
                    </div>
                    <div class=""col-4 col-sm-auto d-flex justify-content-end justify-content-sm-end"">
                        <button class=""btn border bg-light rounded"" style=""width: 45px;"" id=""btn_dec_adult""
                            type=""button"" onclick=""decrement('adult_modal', 'btn_dec_adult', 'btn_inc_adult', 0)""> -
                        </button>
                    </div>
                    <div class=""col-4 col-sm-2"">
                        <input type=""number"" class=""form-control bg-white"" id=""adult_modal"" value=""0"" disabled>
                    </div>
                    <div class=""co");
            WriteLiteral(@"l-4 col-sm-auto d-flex justify-content-start justify-content-sm-start"">
                        <button class=""btn border bg-light rounded"" style=""width: 45px;"" id=""btn_inc_adult""
                            type=""button"" onclick=""increment('adult_modal', 'btn_dec_adult', 'btn_inc_adult', 5)""> +
                        </button>
                    </div>
                </div>
                <!-- Child -->
                <div class=""row justify-content-sm-center border my-2 py-2"">
                    <div class=""col-2 d-flex justify-content-center align-items-center"">
                        <span class=""my-icon-child fs-5""></span>
                    </div>
                    <div class=""col-10 col-sm-2 d-flex justify-content-center"">
                        <div class=""row row-cols-1"">
                            <div class=""col text-center"">Children</div>
                            <div class=""col text-center text-black-50 fw-light"">2-11</div>
                        </div>
           ");
            WriteLiteral(@"         </div>
                    <div class=""col-4 col-sm-auto d-flex justify-content-end justify-content-sm-end"">
                        <button class=""btn border bg-light rounded"" style=""width: 45px;"" id=""btn_dec_child""
                            type=""button"" onclick=""decrement('child_modal', 'btn_dec_child', 'btn_inc_child', 0)""> -
                        </button>
                    </div>
                    <div class=""col-4 col-sm-2"">
                        <input type=""number"" class=""form-control bg-white"" id=""child_modal"" value=""0"" disabled>
                    </div>
                    <div class=""col-4 col-sm-auto d-flex justify-content-start justify-content-sm-start"">
                        <button class=""btn border bg-light rounded"" style=""width: 45px;"" id=""btn_inc_child""
                            type=""button"" onclick=""increment('child_modal', 'btn_dec_child', 'btn_inc_child', 5)""> +
                        </button>
                    </div>
                </div>
  ");
            WriteLiteral(@"              <!-- Infant -->
                <div class=""row justify-content-sm-center border py-2"">
                    <div class=""col-2 d-flex justify-content-center align-items-center"">
                        <span class=""my-icon-infant fs-5""></span>
                    </div>
                    <div class=""col-10 col-sm-2 d-flex justify-content-center"">
                        <div class=""row row-cols-1"">
                            <div class=""col text-center"">Infants</div>
                            <div class=""col text-center text-black-50 fw-light"">Under 2</div>
                        </div>
                    </div>
                    <div class=""col-4 col-sm-auto d-flex justify-content-end justify-content-sm-end"">
                        <button class=""btn border bg-light rounded"" style=""width: 45px;"" id=""btn_dec_infant""
                            type=""button"" onclick=""decrement('infant_modal', 'btn_dec_infant', 'btn_inc_infant', 0)""> -
                        </button>
    ");
            WriteLiteral(@"                </div>
                    <div class=""col-4 col-sm-2"">
                        <input type=""number"" class=""form-control bg-white"" id=""infant_modal"" value=""0"" disabled>
                    </div>
                    <div class=""col-4 col-sm-auto d-flex justify-content-start justify-content-sm-start"">
                        <button class=""btn border bg-light rounded"" style=""width: 45px;"" id=""btn_inc_infant""
                            type=""button"" onclick=""increment('infant_modal', 'btn_dec_infant', 'btn_inc_infant', 5)""> +
                        </button>
                    </div>
                </div>
                <!-- Cancel and Done buttons -->
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cancel</button>
                    <button type=""button"" class=""btn bg-secondary-cs text-white"" data-bs-dismiss=""modal""
                        onclick=""modalInputValues()"">
                   ");
            WriteLiteral(@"     Done
                    </button>
                </div>
                <!-- Bags -->
                <!-- Uncertainly commented to migrate bag form controls to the 3rd process page passenger form. -->
                <!-- <h6 class=""mt-3"">Bags</h6>

                    <hr> -->
                <!-- Types of bag -->
                <!-- Cabin bag -->
                <!-- <div class=""row justify-content-sm-center border py-2"">
                        <div class=""col-2 d-flex justify-content-center align-items-center"">
                            <span class=""my-icon-cabin_bag fs-5""></span>
                        </div>
                        <div class=""col-10 col-sm-2 d-flex justify-content-center"">
                            Cabin bags
                        </div>
                        <div class=""col-4 col-sm-auto d-flex justify-content-end justify-content-sm-end"">
                            <button class=""btn border bg-light rounded"" style=""width: 45px;""> - </button>
     ");
            WriteLiteral(@"                   </div>
                        <div class=""col-4 col-sm-2"">
                            <input type=""number"" class=""form-control"">
                        </div>
                        <div class=""col-4 col-sm-auto d-flex justify-content-start justify-content-sm-start"">
                            <button class=""btn border bg-light rounded"" style=""width: 45px;""> + </button>
                        </div>
                    </div> -->
                <!-- Checked bag -->
                <!-- <div class=""row justify-content-sm-center border mt-2 py-2"">
                        <div class=""col-2 d-flex justify-content-center align-items-center"">
                            <span class=""my-icon-checked_bag fs-5""></span>
                        </div>
                        <div class=""col-10 col-sm-2 d-flex justify-content-center"">
                            Checked bags
                        </div>
                        <div class=""col-4 col-sm-auto d-flex justify-conten");
            WriteLiteral(@"t-end justify-content-sm-end"">
                            <button class=""btn border bg-light rounded"" style=""width: 45px;""> - </button>
                        </div>
                        <div class=""col-4 col-sm-2"">
                            <input type=""number"" class=""form-control"">
                        </div>
                        <div class=""col-4 col-sm-auto d-flex justify-content-start justify-content-sm-start"">
                            <button class=""btn border bg-light rounded"" style=""width: 45px;""> + </button>
                        </div>
                    </div> -->
            </div>
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OTA.Pages.SecondProcessPageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OTA.Pages.SecondProcessPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OTA.Pages.SecondProcessPageModel>)PageContext?.ViewData;
        public OTA.Pages.SecondProcessPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
