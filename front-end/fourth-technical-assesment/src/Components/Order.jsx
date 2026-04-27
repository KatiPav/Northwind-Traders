export default function Order({data}) {
return             <div className="Order">
    <div>Id: {data.orderId}</div>
    <div>Ordered on: {data.orderDate}</div>
    <div>Shipping address: {data.shipAddress}, {data.shipCity} , {data.shipCountry}</div>
            <div>Total: {data.totalValue} $</div>
            <div>Products: {data.productCount}</div>
            </div>
}