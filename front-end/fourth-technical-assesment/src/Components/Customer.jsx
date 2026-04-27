import { useState } from "react";
import { getCusomerDetails } from "../Services/CustomerService"
import CustomerDetails from "./CustomerDetails";

export default function Customer({data}) {
    const [customerDetails, setCustomerDetails] = useState([]);
    const [showDetails, setShowDetails] = useState(false); 
    const [buttonText, setButtonText] = useState("Show Details");
    
    async function displayCustomerDetails(){
        if(!showDetails){
            var result = await getCusomerDetails(data.id);
            setCustomerDetails(result);
            setShowDetails(true);
            setButtonText("Hide Details");
        } else {
            setShowDetails(false);
            setButtonText("Show Details");
        }
    } 

return <div className="Customer">
<div>{data.name}</div>
<div>Number of orders: {data.orderCount}</div>
<div>Company: {data.companyName}</div>
{showDetails && <CustomerDetails data={customerDetails}/>}
<button onClick={displayCustomerDetails}>{buttonText}</button>
</div>
}