namespace Adyen_Payment_Gateway_Demo_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check : DbMigration
    {
        public override void Up()
        {
            AddColumn("payments.AdyenSuccessPaymentLog", "refundAmount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("payments.AdyenSuccessPaymentLog", "refundAmount");
        }
    }
}
