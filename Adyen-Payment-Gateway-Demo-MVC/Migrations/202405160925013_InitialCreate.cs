namespace Adyen_Payment_Gateway_Demo_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "payments.AdyenSuccessPaymentLog",
                c => new
                    {
                        pspReference = c.String(nullable: false, maxLength: 128),
                        resultCode = c.String(),
                        merchantReference = c.String(),
                        currency = c.String(),
                        amount = c.Int(nullable: false),
                        paymentMethodBrand = c.String(),
                        paymentMethodType = c.String(),
                    })
                .PrimaryKey(t => t.pspReference);
            
        }
        
        public override void Down()
        {
            DropTable("payments.AdyenSuccessPaymentLog");
        }
    }
}
