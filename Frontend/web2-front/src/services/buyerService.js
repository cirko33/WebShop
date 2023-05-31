import api from "../api/api";

const getProducts = async() => {
    try {
        const res = await api.get('buyer/products');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return [];
    }
}

const getOrders = async() => {
    try {
        const res = await api.get('buyer/orders');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return [];
    }
}


const postOrder = async(data) => {
    try {
        await api.post('buyer/order', data);
        return true;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return false;
    }
}

const postCancel = async(id) => {
    try {
        await api.post('buyer/cancel-order/' + id);
        return true;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return false;
    }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
    getProducts,
    postOrder,
    getOrders,
    postCancel
}