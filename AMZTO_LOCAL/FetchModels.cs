using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Data;
using HtmlAgilityPack;

namespace AMZTO_LOCAL
{
    /// <summary>
    /// AliExpress web crawling class, a bit of pandorabox.
    /// </summary>
    public class FetchDbData
    {
        private datasourceContext db = new datasourceContext();
        private UploadContext _db = new UploadContext();

        /// <summary>
        /// Do web crawling operation, get pure data then call PutDataSource to make a Datasource lists.
        /// </summary>
        /// <returns></returns>
        public string FetchAllLinks()
        {
            List<itemDataSet> result = new List<itemDataSet>();
            //query all uploaded links
            using (var db = new UploadContext())
            {
                string paths;
                var query = (from p in db.LinkDataSet
                             orderby p.ShopName
                             select p).ToList();

                DataTable dt = new DataTable();
                //foreach link - getproducts informations
                foreach (var q in query)
                {
                    try
                    {
                        paths = q.sourceLink.ToString();
                        result = parseProduct.getProduct(paths);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.ToString());
                        return ex.ToString(); ;
                    }
                }
            }
            //put to datasources
            string opResult = PutDataScources(result);

            return opResult;
        }

        /// <summary>
        /// Fill in some logics and insert pure data to itemDatasource Table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string PutDataScources(List<itemDataSet> source)
        {
            if (source != null)
            {
                try
                {
                    itemDataSource LinkLists = new itemDataSource();

                    //foreach row in Excel, insert it to database
                    foreach (itemDataSet dr in source)
                    {
                        //Check if row in each source group is null or empty
                        if (dr != null)
                        {
                            foreach (itemSpecificationsSet variant in dr.Specifications)
                            {
                                //check each varient group
                                int num_index = 0;
                                String parent_links = "";
                                //each color
                                foreach (String Color in variant.Color)
                                {
                                    LinkLists.ItemColor = Color;
                                    //each size
                                    foreach (String Size in variant.Size)
                                    {
                                        if (Size != "Sizing info")
                                        {
                                            LinkLists.ItemSize = Size;
                                            //each metal color
                                            foreach (itemVaraintsSet MetalColor in variant.MetalColor)
                                            {
                                                LinkLists.MetalType = MetalColor.metalType;
                                                //set parent & child
                                                if (num_index == 0)
                                                {
                                                    LinkLists.ParentID = "Parents";
                                                    LinkLists.ChildID = "";
                                                    parent_links = dr.ProductLink;
                                                    num_index++;
                                                }
                                                else
                                                {
                                                    LinkLists.ParentID = "Child";
                                                    LinkLists.ChildID = parent_links;
                                                }
                                                //set descriptions
                                                string DescriptionArrays = "<ul>";
                                                //concat descriptions
                                                foreach (itemDescriptionsSet Desc in dr.Descriptions)
                                                {
                                                    DescriptionArrays = DescriptionArrays + "<li>" + Desc.descType + " : " + Desc.descValue + "</li>";
                                                }
                                                LinkLists.Description = DescriptionArrays + "</ul>";

                                                //Set small Images
                                                int sum_index = 0;
                                                String[] imageArrays = new String[6];

                                                //each small image
                                                foreach (String image in dr.smallImage)
                                                {
                                                    if ((sum_index < 6))
                                                    {
                                                        if (String.IsNullOrEmpty(image))
                                                        {
                                                            imageArrays[sum_index] = "No Image";
                                                        }
                                                        else
                                                        {
                                                            imageArrays[sum_index] = image;
                                                        }
                                                        sum_index++;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                LinkLists.SmallImage1 = imageArrays[0];
                                                LinkLists.SmallImage2 = imageArrays[1];
                                                LinkLists.SmallImage3 = imageArrays[2];
                                                LinkLists.SmallImage4 = imageArrays[3];
                                                LinkLists.SmallImage5 = imageArrays[4];
                                                LinkLists.SmallImage6 = imageArrays[5];

                                                //set Link Image
                                                if (String.IsNullOrEmpty(MetalColor.bigpic) || (MetalColor.bigpic == "No Image"))
                                                {
                                                    LinkLists.ImageLink = dr.ImageLink;
                                                }
                                                else
                                                {
                                                    LinkLists.ImageLink = MetalColor.bigpic;
                                                }

                                                //set common attributes
                                                LinkLists.isStock = dr.isStock;
                                                LinkLists.Source = dr.Source;
                                                LinkLists.SalesPrice = dr.SalesPrice;
                                                LinkLists.OriginalPrice = dr.OriginalPrice;
                                                LinkLists.ProductLink = dr.ProductLink;
                                                LinkLists.ProductID = dr.ProductID;
                                                LinkLists.ProductName = dr.ProductName;
                                                LinkLists.Remarks = dr.ShopName;
                                                LinkLists.UserID = "1";
                                                LinkLists.LinkID = 1;
                                                //Check if sourcesLinks Exists
                                                var query = (from p in db.itemDataSource
                                                             where p.ProductLink == LinkLists.ProductLink &&
                                                                    p.ItemSize == LinkLists.ItemSize &&
                                                                    p.ItemColor == LinkLists.ItemColor &&
                                                                    p.MetalType == LinkLists.MetalType &&
                                                                    p.UserID == "1" &&
                                                                    p.LinkID == 1
                                                             select p).ToList();
                                                //foreach link - getproducts informations
                                                if (!query.Any())
                                                {
                                                    db.itemDataSource.Add(LinkLists);
                                                    db.SaveChanges();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }

                return "0";
            }
            return "source is null, get child node error.";
        }
    }

    public class itemDescriptionsSet
    {
        public String descType { get; set; }
        public String descValue { get; set; }
    }

    public class itemVaraintsSet
    {
        public String metalType { get; set; }
        public String bigpic { get; set; }
    }

    public class itemSpecificationsSet
    {
        public List<String> Color { get; set; }
        public List<itemVaraintsSet> MetalColor { get; set; }
        public List<String> Size { get; set; }
        public List<String> miscData { get; set; }
        public itemSpecificationsSet()
        {
            MetalColor = new List<itemVaraintsSet>();
            Color = new List<String>();
            Size = new List<String>();
            miscData = new List<String>();
        }
    }

    public class smallImageSet
    {
        public List<String> ImageLinks { get; set; }
        public smallImageSet()
        {
            ImageLinks = new List<String>();
        }
    }

    public class itemDataSet
    {
        public String ProductID { get; set; }
        public String ProductName { get; set; }
        public String ProductLink { get; set; }
        public String SalesPrice { get; set; }
        public String OriginalPrice { get; set; }

        public String ParentID { get; set; }
        public String ChildID { get; set; }

        public String ImageLink { get; set; }
        public List<itemDescriptionsSet> Descriptions { get; set; }
        public List<itemSpecificationsSet> Specifications { get; set; }

        public bool isStock { get; set; }
        public List<String> smallImage { get; set; }
        public String ShopName { get; set; }
        public String LinkType { get; set; }
        public String Source { get; set; }
        public itemDataSet()
        {
            Descriptions = new List<itemDescriptionsSet>();
            Specifications = new List<itemSpecificationsSet>();
            smallImage = new List<String>();
        }
    }
}