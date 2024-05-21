namespace Adyen_Payment_Gateway_Demo_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("payments.AdyenSuccessPaymentLog", "amount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("payments.AdyenSuccessPaymentLog", "amount", c => c.Int(nullable: false));
        }
    }
}
