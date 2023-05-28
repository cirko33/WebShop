import { useEffect, useState } from "react";
import adminService from "../../../services/adminService";
import Orders from "../../../reusable/Order/Orders";

const AllOrders = () => {
  const [orders, setOrders] = useState(null);

  useEffect(() => {
    adminService.getOrders().then((res) => {
      setOrders(res.orders);
    });
  }, []);

  return (
    <Orders orders={orders} title={"All orders"}/>
  );
};

export default AllOrders;
