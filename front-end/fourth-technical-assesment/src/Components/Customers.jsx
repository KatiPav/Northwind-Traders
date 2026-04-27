import { useState } from "react"
import { getCustomers } from "../Services/CustomerService"
import Customer from "./Customer";
import "../css/Customers.css";

export default function Customers(){
    const [customersData, setCustomersData] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [name, setName] = useState("");
    
    async function handleCustomersButtonClick(){
        setIsLoading(true);
        const result = await getCustomers(name);
        setCustomersData(result);
        setIsLoading(false);
    }
return <><div className="CustomersSearchBar"><input
      value={name}
      onChange={e => setName(e.target.value)}></input>
    <button onClick={handleCustomersButtonClick}>Search</button>
        </div>
    <div className="Customers">
    {isLoading ? (<div> Loading...</div>) : 
    (customersData.map(cust => (<Customer key={cust.id} data={cust}></Customer>)))}
</div></>
}