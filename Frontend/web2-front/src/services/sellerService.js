import api from "../api/api"


const getNewOrders = async() => {
    try {
        const res = await api.get('seller/new-orders');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        Promise.reject(e);
    }
}

const getMyOrders = async() => {
    try {
        const res = await api.get('seller/orders');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        Promise.reject(e);
    }
}

const getProducts= async() => {
    try {
        const res = await api.get('seller/products');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        Promise.reject(e);
    }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
    getNewOrders,
    getMyOrders,
    getProducts
}