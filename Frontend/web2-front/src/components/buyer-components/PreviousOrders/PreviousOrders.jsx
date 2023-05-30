import { useEffect, useState } from "react";
import buyerService from "../../../services/buyerService";
import Orders from "../../../reusable/Order/Orders";

const PreviousOrders = () => {
    const [orders, setOrders] = useState([]);
    useEffect(() => {
      buyerService.getOrders().then((res) => setOrders(res));
    }, []);
    return <Orders orders={orders} title={"New orders"} />;
}
 
export default PreviousOrders;