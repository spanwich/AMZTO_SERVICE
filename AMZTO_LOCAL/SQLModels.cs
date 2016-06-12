using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
//using System.Web.Security;
using System.Linq;

namespace AMZTO_LOCAL
{
    public class datasourceContext : DbContext
    {
        public datasourceContext()
            : base("DefaultConnection")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<datasourceContext>());
            //Database.SetInitializer<datasourceContext>(null);
        }
        public DbSet<itemDataSource> itemDataSource { get; set; }
        public DbSet<masterTemplates> masterTemplates { get; set; }
        public DbSet<accountDetails> accountDetails { get; set; }
        public DbSet<amazonTemplates> amazonTemplates { get; set; }
        public DbSet<productMasterCollection> productMasterCollection { get; set; }
        public DbSet<templateCollection> templateCollection { get; set; }
        public DbSet<orderUploadCollection> orderUploadCollection { get; set; }
        public DbSet<messageCollection> messageCollection { get; set; }
        public DbSet<GlobalSetting> GlobalSettings { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

    }

    [Table("itemDatasource")]
    public class itemDataSource
    {
        [Key]
        public int dataSourceID { get; set; }
        public string UserID { get; set; }
        public int LinkID { get; set; }
        public int FetchCount { get; set; }
        public String ProductID { get; set; }
        public String ProductName { get; set; }
        public String ProductLink { get; set; }
        public String SalesPrice { get; set; }
        public String OriginalPrice { get; set; }

        public String ParentID { get; set; }
        public String ChildID { get; set; }

        public String ImageLink { get; set; }
        public String MetalType { get; set; }
        public String ItemColor { get; set; }
        public String ItemSize { get; set; }
        public String miscData { get; set; }
        public String Description { get; set; }
        public String SmallImage1 { get; set; }
        public String SmallImage2 { get; set; }
        public String SmallImage3 { get; set; }
        public String SmallImage4 { get; set; }
        public String SmallImage5 { get; set; }
        public String SmallImage6 { get; set; }
        public bool isStock { get; set; }
        public String Remarks { get; set; }
        public String Source { get; set; }
    }

    [Table("masterTemplates")]
    public class masterTemplates
    {
        [Key]
        public int masterID { get; set; }
        public String masterName { get; set; }
        public String item_sku { get; set; }
        public String item_name { get; set; }
        public String manufacturer { get; set; }
        public String model { get; set; }
        public String feed_product_type { get; set; }
        public String item_type { get; set; }
        public String brand_name { get; set; }
        public String external_product_id { get; set; }
        public String external_product_id_type { get; set; }
        public String product_description { get; set; }
        public String update_delete { get; set; }
        public String standard_price { get; set; }
        public String quantity { get; set; }
        public String currency { get; set; }
        public String product_site_launch_date { get; set; }
        public String product_tax_code { get; set; }
        public String list_price { get; set; }
        public String sale_price { get; set; }
        public String sale_from_date { get; set; }
        public String sale_end_date { get; set; }
        public String merchant_release_date { get; set; }
        public String item_package_quantity { get; set; }
        public String fulfillment_latency { get; set; }
        public String restock_date { get; set; }
        public String max_aggregate_ship_quantity { get; set; }
        public String offering_can_be_gift_messaged { get; set; }
        public String offering_can_be_giftwrapped { get; set; }
        public String is_discontinued_by_manufacturer { get; set; }
        public String missing_keyset_reason { get; set; }
        public String delivery_schedule_group_id { get; set; }
	public String merchant_shipping_group_name { get; set; }
        public String website_shipping_weight { get; set; }
        public String website_shipping_weight_unit_of_measure { get; set; }
        public String display_dimensions_unit_of_measure { get; set; }
        public String item_display_diameter { get; set; }
        public String item_display_height { get; set; }
        public String item_display_width { get; set; }
        public String item_display_length { get; set; }
        public String item_length { get; set; }
        public String item_width { get; set; }
        public String item_height { get; set; }
        public String item_dimensions_unit_of_measure { get; set; }
        public String bullet_point1 { get; set; }
        public String bullet_point2 { get; set; }
        public String bullet_point3 { get; set; }
        public String bullet_point4 { get; set; }
        public String bullet_point5 { get; set; }
        public String target_audience_keywords1 { get; set; }
        public String target_audience_keywords2 { get; set; }
        public String target_audience_keywords3 { get; set; }
        public String catalog_number { get; set; }
        public String specific_uses_keywords1 { get; set; }
        public String specific_uses_keywords2 { get; set; }
        public String specific_uses_keywords3 { get; set; }
        public String specific_uses_keywords4 { get; set; }
        public String specific_uses_keywords5 { get; set; }
        public String thesaurus_attribute_keywords1 { get; set; }
        public String thesaurus_attribute_keywords2 { get; set; }
        public String thesaurus_attribute_keywords3 { get; set; }
        public String thesaurus_attribute_keywords4 { get; set; }
        public String thesaurus_attribute_keywords5 { get; set; }
        public String thesaurus_subject_keywords1 { get; set; }
        public String thesaurus_subject_keywords2 { get; set; }
        public String thesaurus_subject_keywords3 { get; set; }
        public String thesaurus_subject_keywords4 { get; set; }
        public String thesaurus_subject_keywords5 { get; set; }
        public String generic_keywords1 { get; set; }
        public String generic_keywords2 { get; set; }
        public String generic_keywords3 { get; set; }
        public String generic_keywords4 { get; set; }
        public String generic_keywords5 { get; set; }
        public String platinum_keywords1 { get; set; }
        public String platinum_keywords2 { get; set; }
        public String platinum_keywords3 { get; set; }
        public String platinum_keywords4 { get; set; }
        public String platinum_keywords5 { get; set; }
        public String main_image_url { get; set; }
        public String swatch_image_url { get; set; }
        public String other_image_url1 { get; set; }
        public String other_image_url2 { get; set; }
        public String other_image_url3 { get; set; }
        public String other_image_url4 { get; set; }
        public String other_image_url5 { get; set; }
        public String other_image_url6 { get; set; }
        public String other_image_url7 { get; set; }
        public String other_image_url8 { get; set; }
        public String fulfillment_center_id { get; set; }
        public String package_length { get; set; }
        public String package_height { get; set; }
        public String package_width { get; set; }
        public String package_dimensions_unit_of_measure { get; set; }
        public String package_weight { get; set; }
        public String package_weight_unit_of_measure { get; set; }
        public String parent_child { get; set; }
        public String parent_sku { get; set; }
        public String relationship_type { get; set; }
        public String variation_theme { get; set; }
        public String country_of_origin { get; set; }
        public String prop_65 { get; set; }
        public String cpsia_cautionary_statement1 { get; set; }
        public String cpsia_cautionary_statement2 { get; set; }
        public String cpsia_cautionary_statement3 { get; set; }
        public String cpsia_cautionary_statement4 { get; set; }
        public String cpsia_cautionary_description { get; set; }
        public String department_name { get; set; }
        public String designer { get; set; }
        public String total_metal_weight { get; set; }
        public String total_metal_weight_unit_of_measure { get; set; }
        public String total_diamond_weight { get; set; }
        public String total_diamond_weight_unit_of_measure { get; set; }
        public String total_gem_weight { get; set; }
        public String total_gem_weight_unit_of_measure { get; set; }
        public String material_type1 { get; set; }
        public String material_type2 { get; set; }
        public String material_type3 { get; set; }
        public String material_type4 { get; set; }
        public String metal_type { get; set; }
        public String metal_stamp { get; set; }
        public String setting_type { get; set; }
        public String number_of_stones { get; set; }
        public String clasp_type { get; set; }
        public String chain_type { get; set; }
        public String ring_size { get; set; }
        public String is_resizable { get; set; }
        public String ring_sizing_lower_range { get; set; }
        public String ring_sizing_upper_range { get; set; }
        public String estate_period { get; set; }
        public String certificate_number1 { get; set; }
        public String certificate_number2 { get; set; }
        public String certificate_number3 { get; set; }
        public String certificate_number4 { get; set; }
        public String certificate_number5 { get; set; }
        public String certificate_number6 { get; set; }
        public String certificate_number7 { get; set; }
        public String certificate_number8 { get; set; }
        public String certificate_number9 { get; set; }
        public String gem_type1 { get; set; }
        public String gem_type2 { get; set; }
        public String gem_type3 { get; set; }
        public String stone_cut1 { get; set; }
        public String stone_cut2 { get; set; }
        public String stone_cut3 { get; set; }
        public String stone_color1 { get; set; }
        public String stone_color2 { get; set; }
        public String stone_color3 { get; set; }
        public String stone_clarity1 { get; set; }
        public String stone_clarity2 { get; set; }
        public String stone_clarity3 { get; set; }
        public String stone_shape1 { get; set; }
        public String stone_shape2 { get; set; }
        public String stone_shape3 { get; set; }
        public String stone_creation_method1 { get; set; }
        public String stone_creation_method2 { get; set; }
        public String stone_creation_method3 { get; set; }
        public String stone_treatment_method1 { get; set; }
        public String stone_treatment_method2 { get; set; }
        public String stone_treatment_method3 { get; set; }
        public String stone_dimensions_unit_of_measure1 { get; set; }
        public String stone_dimensions_unit_of_measure2 { get; set; }
        public String stone_dimensions_unit_of_measure3 { get; set; }
        public String stone_height1 { get; set; }
        public String stone_height2 { get; set; }
        public String stone_height3 { get; set; }
        public String stone_length1 { get; set; }
        public String stone_length2 { get; set; }
        public String stone_length3 { get; set; }
        public String stone_width1 { get; set; }
        public String stone_width2 { get; set; }
        public String stone_width3 { get; set; }
        public String stone_weight1 { get; set; }
        public String stone_weight2 { get; set; }
        public String stone_weight3 { get; set; }
        public String certificate_type1 { get; set; }
        public String certificate_type2 { get; set; }
        public String certificate_type3 { get; set; }
        public String certificate_type4 { get; set; }
        public String certificate_type5 { get; set; }
        public String certificate_type6 { get; set; }
        public String certificate_type7 { get; set; }
        public String certificate_type8 { get; set; }
        public String certificate_type9 { get; set; }
        public String is_lab_created1 { get; set; }
        public String is_lab_created2 { get; set; }
        public String is_lab_created3 { get; set; }
        public String inscription1 { get; set; }
        public String inscription2 { get; set; }
        public String inscription3 { get; set; }
        public String stone_depth_percentage1 { get; set; }
        public String stone_depth_percentage2 { get; set; }
        public String stone_depth_percentage3 { get; set; }
        public String stone_table_percentage1 { get; set; }
        public String stone_table_percentage2 { get; set; }
        public String stone_table_percentage3 { get; set; }
        public String stone_symmetry1 { get; set; }
        public String stone_symmetry2 { get; set; }
        public String stone_symmetry3 { get; set; }
        public String stone_polish1 { get; set; }
        public String stone_polish2 { get; set; }
        public String stone_polish3 { get; set; }
        public String stone_girdle1 { get; set; }
        public String stone_girdle2 { get; set; }
        public String stone_girdle3 { get; set; }
        public String stone_culet1 { get; set; }
        public String stone_culet2 { get; set; }
        public String stone_culet3 { get; set; }
        public String stone_fluorescence1 { get; set; }
        public String stone_fluorescence2 { get; set; }
        public String stone_fluorescence3 { get; set; }
        public String pearl_type { get; set; }
        public String pearl_minimum_color { get; set; }
        public String pearl_lustre { get; set; }
        public String pearl_shape { get; set; }
        public String pearl_uniformity { get; set; }
        public String pearl_surface_blemishes { get; set; }
        public String nacre_thickness { get; set; }
        public String pearl_stringing_method { get; set; }
        public String size_per_pearl { get; set; }
        public String number_of_pearls { get; set; }
        public String style_name { get; set; }
        public String color_name { get; set; }
        public String back_finding { get; set; }
    }

    [Table("accountDetails")]
    public class accountDetails
    {
        [Key]
        public int accountID { get; set; }
        public String sku_code_Account { get; set; }
        public String BrandName { get; set; }
        public String Keyword1 { get; set; }
        public String Keyword2 { get; set; }
        public String Keyword3 { get; set; }
        public String Keyword4 { get; set; }
        public String Keyword5 { get; set; }
        public String Fullfilment { get; set; }
        public String Currency { get; set; }
        public String Profit { get; set; }
        public String StartSKUNo { get; set; }
        public String Quantity { get; set; }
        public String SaleFromDate { get; set; }
        public String SaleEndDate { get; set; }
    }

    [Table("amazonTemplates")]
    public class amazonTemplates
    {
        [Key]
        public int templateID { get; set; }
        public String fileName { get; set; }
        public String item_sku { get; set; }
        public String item_name { get; set; }
        public String manufacturer { get; set; }
        public String model { get; set; }
        public String feed_product_type { get; set; }
        public String item_type { get; set; }
        public String brand_name { get; set; }
        public String external_product_id { get; set; }
        public String external_product_id_type { get; set; }
        public String product_description { get; set; }
        public String update_delete { get; set; }
        public String standard_price { get; set; }
        public String quantity { get; set; }
        public String currency { get; set; }
        public String product_site_launch_date { get; set; }
        public String product_tax_code { get; set; }
        public String list_price { get; set; }
        public String sale_price { get; set; }
        public String sale_from_date { get; set; }
        public String sale_end_date { get; set; }
        public String merchant_release_date { get; set; }
        public String item_package_quantity { get; set; }
        public String fulfillment_latency { get; set; }
        public String restock_date { get; set; }
        public String max_aggregate_ship_quantity { get; set; }
        public String offering_can_be_gift_messaged { get; set; }
        public String offering_can_be_giftwrapped { get; set; }
        public String is_discontinued_by_manufacturer { get; set; }
        public String missing_keyset_reason { get; set; }
        public String delivery_schedule_group_id { get; set; }
	public String merchant_shipping_group_name { get; set; }
        public String website_shipping_weight { get; set; }
        public String website_shipping_weight_unit_of_measure { get; set; }
        public String display_dimensions_unit_of_measure { get; set; }
        public String item_display_diameter { get; set; }
        public String item_display_height { get; set; }
        public String item_display_width { get; set; }
        public String item_display_length { get; set; }
        public String item_length { get; set; }
        public String item_width { get; set; }
        public String item_height { get; set; }
        public String item_dimensions_unit_of_measure { get; set; }
        public String bullet_point1 { get; set; }
        public String bullet_point2 { get; set; }
        public String bullet_point3 { get; set; }
        public String bullet_point4 { get; set; }
        public String bullet_point5 { get; set; }
        public String target_audience_keywords1 { get; set; }
        public String target_audience_keywords2 { get; set; }
        public String target_audience_keywords3 { get; set; }
        public String catalog_number { get; set; }
        public String specific_uses_keywords1 { get; set; }
        public String specific_uses_keywords2 { get; set; }
        public String specific_uses_keywords3 { get; set; }
        public String specific_uses_keywords4 { get; set; }
        public String specific_uses_keywords5 { get; set; }
        public String thesaurus_attribute_keywords1 { get; set; }
        public String thesaurus_attribute_keywords2 { get; set; }
        public String thesaurus_attribute_keywords3 { get; set; }
        public String thesaurus_attribute_keywords4 { get; set; }
        public String thesaurus_attribute_keywords5 { get; set; }
        public String thesaurus_subject_keywords1 { get; set; }
        public String thesaurus_subject_keywords2 { get; set; }
        public String thesaurus_subject_keywords3 { get; set; }
        public String thesaurus_subject_keywords4 { get; set; }
        public String thesaurus_subject_keywords5 { get; set; }
        public String generic_keywords1 { get; set; }
        public String generic_keywords2 { get; set; }
        public String generic_keywords3 { get; set; }
        public String generic_keywords4 { get; set; }
        public String generic_keywords5 { get; set; }
        public String platinum_keywords1 { get; set; }
        public String platinum_keywords2 { get; set; }
        public String platinum_keywords3 { get; set; }
        public String platinum_keywords4 { get; set; }
        public String platinum_keywords5 { get; set; }
        public String main_image_url { get; set; }
        public String swatch_image_url { get; set; }
        public String other_image_url1 { get; set; }
        public String other_image_url2 { get; set; }
        public String other_image_url3 { get; set; }
        public String other_image_url4 { get; set; }
        public String other_image_url5 { get; set; }
        public String other_image_url6 { get; set; }
        public String other_image_url7 { get; set; }
        public String other_image_url8 { get; set; }
        public String fulfillment_center_id { get; set; }
        public String package_length { get; set; }
        public String package_height { get; set; }
        public String package_width { get; set; }
        public String package_dimensions_unit_of_measure { get; set; }
        public String package_weight { get; set; }
        public String package_weight_unit_of_measure { get; set; }
        public String parent_child { get; set; }
        public String parent_sku { get; set; }
        public String relationship_type { get; set; }
        public String variation_theme { get; set; }
        public String country_of_origin { get; set; }
        public String prop_65 { get; set; }
        public String cpsia_cautionary_statement1 { get; set; }
        public String cpsia_cautionary_statement2 { get; set; }
        public String cpsia_cautionary_statement3 { get; set; }
        public String cpsia_cautionary_statement4 { get; set; }
        public String cpsia_cautionary_description { get; set; }
        public String department_name { get; set; }
        public String designer { get; set; }
        public String total_metal_weight { get; set; }
        public String total_metal_weight_unit_of_measure { get; set; }
        public String total_diamond_weight { get; set; }
        public String total_diamond_weight_unit_of_measure { get; set; }
        public String total_gem_weight { get; set; }
        public String total_gem_weight_unit_of_measure { get; set; }
        public String material_type1 { get; set; }
        public String material_type2 { get; set; }
        public String material_type3 { get; set; }
        public String material_type4 { get; set; }
        public String metal_type { get; set; }
        public String metal_stamp { get; set; }
        public String setting_type { get; set; }
        public String number_of_stones { get; set; }
        public String clasp_type { get; set; }
        public String chain_type { get; set; }
        public String ring_size { get; set; }
        public String is_resizable { get; set; }
        public String ring_sizing_lower_range { get; set; }
        public String ring_sizing_upper_range { get; set; }
        public String estate_period { get; set; }
        public String certificate_number1 { get; set; }
        public String certificate_number2 { get; set; }
        public String certificate_number3 { get; set; }
        public String certificate_number4 { get; set; }
        public String certificate_number5 { get; set; }
        public String certificate_number6 { get; set; }
        public String certificate_number7 { get; set; }
        public String certificate_number8 { get; set; }
        public String certificate_number9 { get; set; }
        public String gem_type1 { get; set; }
        public String gem_type2 { get; set; }
        public String gem_type3 { get; set; }
        public String stone_cut1 { get; set; }
        public String stone_cut2 { get; set; }
        public String stone_cut3 { get; set; }
        public String stone_color1 { get; set; }
        public String stone_color2 { get; set; }
        public String stone_color3 { get; set; }
        public String stone_clarity1 { get; set; }
        public String stone_clarity2 { get; set; }
        public String stone_clarity3 { get; set; }
        public String stone_shape1 { get; set; }
        public String stone_shape2 { get; set; }
        public String stone_shape3 { get; set; }
        public String stone_creation_method1 { get; set; }
        public String stone_creation_method2 { get; set; }
        public String stone_creation_method3 { get; set; }
        public String stone_treatment_method1 { get; set; }
        public String stone_treatment_method2 { get; set; }
        public String stone_treatment_method3 { get; set; }
        public String stone_dimensions_unit_of_measure1 { get; set; }
        public String stone_dimensions_unit_of_measure2 { get; set; }
        public String stone_dimensions_unit_of_measure3 { get; set; }
        public String stone_height1 { get; set; }
        public String stone_height2 { get; set; }
        public String stone_height3 { get; set; }
        public String stone_length1 { get; set; }
        public String stone_length2 { get; set; }
        public String stone_length3 { get; set; }
        public String stone_width1 { get; set; }
        public String stone_width2 { get; set; }
        public String stone_width3 { get; set; }
        public String stone_weight1 { get; set; }
        public String stone_weight2 { get; set; }
        public String stone_weight3 { get; set; }
        public String certificate_type1 { get; set; }
        public String certificate_type2 { get; set; }
        public String certificate_type3 { get; set; }
        public String certificate_type4 { get; set; }
        public String certificate_type5 { get; set; }
        public String certificate_type6 { get; set; }
        public String certificate_type7 { get; set; }
        public String certificate_type8 { get; set; }
        public String certificate_type9 { get; set; }
        public String is_lab_created1 { get; set; }
        public String is_lab_created2 { get; set; }
        public String is_lab_created3 { get; set; }
        public String inscription1 { get; set; }
        public String inscription2 { get; set; }
        public String inscription3 { get; set; }
        public String stone_depth_percentage1 { get; set; }
        public String stone_depth_percentage2 { get; set; }
        public String stone_depth_percentage3 { get; set; }
        public String stone_table_percentage1 { get; set; }
        public String stone_table_percentage2 { get; set; }
        public String stone_table_percentage3 { get; set; }
        public String stone_symmetry1 { get; set; }
        public String stone_symmetry2 { get; set; }
        public String stone_symmetry3 { get; set; }
        public String stone_polish1 { get; set; }
        public String stone_polish2 { get; set; }
        public String stone_polish3 { get; set; }
        public String stone_girdle1 { get; set; }
        public String stone_girdle2 { get; set; }
        public String stone_girdle3 { get; set; }
        public String stone_culet1 { get; set; }
        public String stone_culet2 { get; set; }
        public String stone_culet3 { get; set; }
        public String stone_fluorescence1 { get; set; }
        public String stone_fluorescence2 { get; set; }
        public String stone_fluorescence3 { get; set; }
        public String pearl_type { get; set; }
        public String pearl_minimum_color { get; set; }
        public String pearl_lustre { get; set; }
        public String pearl_shape { get; set; }
        public String pearl_uniformity { get; set; }
        public String pearl_surface_blemishes { get; set; }
        public String nacre_thickness { get; set; }
        public String pearl_stringing_method { get; set; }
        public String size_per_pearl { get; set; }
        public String number_of_pearls { get; set; }
        public String style_name { get; set; }
        public String color_name { get; set; }
        public String back_finding { get; set; }
    }

    [Table("productMasterCollection")]
    public class productMasterCollection
    {
        [Key]
        public string model { get; set; }

        public string Link { get; set; }

        public string Name24 { get; set; }

        public string style { get; set; }

        public System.Nullable<int> obsolete { get; set; }

        public System.Nullable<int> type { get; set; }

        public string ASIN { get; set; }

        public string Username { get; set; }

        public System.Nullable<decimal> price_init { get; set; }

        public System.Nullable<decimal> price_current { get; set; }

        public System.Nullable<decimal> price_lowlow { get; set; }

        public System.Nullable<decimal> price_low { get; set; }

        public string images { get; set; }
    }

    [Table("orderUploadCollection")]
    public class orderUploadCollection
    {
        [Key]
        public long order_index { get; set; }

        public string OrderID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string SKU { get; set; }

        public string Quantity { get; set; }

        public string OrderDate { get; set; }

        public string Tracking { get; set; }

        public System.Nullable<short> flags { get; set; }

        public string shippingURL { get; set; }

        public System.Nullable<System.DateTime> add_date { get; set; }

        public string add_user { get; set; }
    }

    [Table("templateCollection")]
    public class templateCollection
    {
        [Key]
        public int template_index { get; set; }

        public string ImageLinks { get; set; }

        public string Username { get; set; }

        public string ASIN { get; set; }

        public string ProductName { get; set; }

        public string Parent { get; set; }

        public int type { get; set; }

        public string Size { get; set; }

        public string Child { get; set; }

        public string StdPrice { get; set; }

        public string SalePrice { get; set; }

        public string STOCK { get; set; }

        public string Descriptions { get; set; }

        public string image1 { get; set; }

        public string image2 { get; set; }

        public string image3 { get; set; }

        public string image4 { get; set; }

        public string image5 { get; set; }

        public string image6 { get; set; }
    }

    [Table("messageCollection")]
    public class messageCollection
    {
        [Key]
        public int message_index { get; set; }

        public string orderID { get; set; }

        public string Username { get; set; }

        public string ClientName { get; set; }

        public int isAuthorized { get; set; }

        public int isAtoZGurantee { get; set; }

        public int type { get; set; }

        public string update_date { get; set; }

        public string message_date { get; set; }

        public string message_body { get; set; }

        public string attached_files { get; set; }
    }

    [Table("GlobalSetting")]
    public class GlobalSetting
    {
        [Key]
        public int Id { get; set; }
        public string ConfigVar { get; set; }
        public string ConfigVal { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}