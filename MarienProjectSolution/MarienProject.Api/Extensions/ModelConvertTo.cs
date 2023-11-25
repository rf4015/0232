namespace MarienProject.Api.Extentions;
using MarienProject.Api.Models;
using MarienProject.Models.Dtos;
using MarienProject.Models.Dtos.Actions;

public static class ModelConvertTo
{
	public static object[] ConvertToModel(this SaveEmployeeDto employeeDto)
	{
		UserProfile userProfile = new UserProfile
		{
			UserName = employeeDto.UserName,
			UserPassaword = employeeDto.UserPassword,
			ProfileImage = employeeDto.ProfileImage,

		};
		Employee employee = new Employee
		{
			FirstNames = employeeDto.FirstNames,
			LastNames = employeeDto.LastNames,
			EmailAddress = employeeDto.EmailAddress,
			Dni = employeeDto.Dni,
			State = employeeDto.State,
			Phone = employeeDto.Phone,
			RoleId = employeeDto.RoleId
		};
		return new object[] { employee, userProfile };
	}
    public static Customer ConvertToCustomer(this CustomerDto customerDto)
    {
        return new Customer
        {
            Id = customerDto.Id,
            FirstNames = customerDto.FirstNames,
            LastNames = customerDto.LastNames,
            EmailAddress = customerDto.EmailAddress,
            State = customerDto.State,
            Phone = customerDto.Phone
        };
    }

    public static Customer ConvertToAddCustomer(this CustomerActionsDto customerDto)
    {
        return new Customer
        {
            FirstNames = customerDto.FirstNames,
            LastNames = customerDto.LastNames,
            EmailAddress = customerDto.EmailAddress,
            Phone = customerDto.Phone,
            RoleId = 4
        };
    }

    public static object[] CreateCustomerActs(this CreateCustomerActions user)
    {
        UserProfile UserProfile = new UserProfile()
        {
            UserName = user.UserName,
            UserPassaword = user.UserPassword,
            ProfileImage = user.ProfileImage
        };
        Customer customer = new Customer() 
        {
            FirstNames = user.FirstNames,
            LastNames = user.LastNames,
            EmailAddress = user.EmailAddress,
            Phone = user.Phone,
            RoleId = 4,
            State = true
        };
        return new object[] { customer, UserProfile };
    }

    public static Role ConvertToRole(this RoleDto roleDto)
	{
		return new Role()
		{
			Id = roleDto.Id,
			Name = roleDto.Name,
			Description = roleDto.Description,
		};
	}
    public static Role ConvertToAddRole(this RoleActionsDto roleDto)
    {
        return new Role()
        {
            Name = roleDto.Name,
            Description = roleDto.Description
        };
    }

    public static Sale ConvertToSale(this SaleDto sale)
    {
        return new Sale() 
        {
            Id = sale.Id,
            CustomerId = sale.CustomerId,
            InvoiceStatusId = sale.InvoiceStatusId,
            DeliveryTypeId = sale.DeliveryTypeId,
            EmployeeId = sale.EmployeeId,
            MunicipalityId = sale.MunicipalityId,
            DeliveryEmployeeId = sale.DeliveryEmployeeId,
            ShippingDate = sale.ShippingDate,
            OrderDate = sale.OrderDate,
            DeliveryDate = sale.DeliveryDate,
            Address = sale.Address,
            Residence = sale.Residence,
            PostalCode = sale.PostalCode,
            CreditCardNumber = sale.CreditCardNumber
        };
    }
    public static Sale ConvertAddToSale(this SaleActionsDto sale)
    {
        return new Sale()
        {
            CustomerId = sale.CustomerId,
            InvoiceStatusId = sale.InvoiceStatusId,
            DeliveryTypeId = sale.DeliveryTypeId,
            EmployeeId = sale.EmployeeId,
            MunicipalityId = sale.MunicipalityId,
            DeliveryEmployeeId = sale.DeliveryEmployeeId,
            ShippingDate = DateTime.Now,
            OrderDate = DateTime.Now,
            DeliveryDate = DateTime.Now,
            Address = sale.Address,
            Residence = sale.Residence,
            PostalCode = sale.PostalCode,
            CreditCardNumber = sale.CreditCardNumber
        };
    }
    public static SaleDetail ConverToSaleDetail(SaleDetailDto sale)
    {
        return new SaleDetail() 
        {
            Id = sale.Id,
            SaleId = sale.SaleId,
            MedicationInStockId = sale.MedicationInStockId,
            Price = sale.Price,
            Quantity = sale.Quantity,
            Discount = sale.Discount,
            Tax = sale.Tax,
            Subtotal = sale.Subtotal,
            Total = sale.Total
        };
    }
    public static SaleDetail ConverToAddSaleDetail(this SaleDetailActionsDto sale)
    {
        return new SaleDetail()
        {
            MedicationInStockId = sale.MedicationInStockId,
            Quantity = sale.Quantity,
            Discount = sale.Discount,
            Tax = sale.Tax
        };
    }
}
