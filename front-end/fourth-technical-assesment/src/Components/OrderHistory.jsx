import { useState } from "react"
import Order from "./Order"

export default function OrderHistory({data}){
    return <div className="OrderHistory">
        <div>Orders</div>
        {data.map((order) => (<Order key={order.orderId} data={order}/>
) )}
        </div>
}