import OrderHistory from "./OrderHistory"

export default function CustomerDetails({data}){
    return <div className="CustomerDetails">
    <div>Contact: {data.contactName} - {data.contactTitle}</div>
    <div>Address: {data.city}, {data.country} {data.address}</div>
    <div>Postal code: {data.postalCode}</div>
    
    <div>Phone: {data.phone}</div>
    <div>Fax: {data.fax}</div>
    <div>Region: {data.region}</div>
    <OrderHistory data={data.orderHistory}></OrderHistory>
    </div>
}