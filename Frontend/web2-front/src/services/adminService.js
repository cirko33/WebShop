import api from '../api/api'

const getVerifiedUsers = async() => {
    try {
        const res = await api.get('admin/verified-users');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return Promise.reject(e);
    }
}

const getWaitingUsers = async() => {
    try {
        const res = await api.get('admin/waiting-users');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return Promise.reject(e);
    }
}

const getOrders = async() => {
    try {
        const res = await api.get('admin/orders');
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return Promise.reject(e);
    }
}

const postVerifyUser = async(data) => {
    try {
        const res = await api.post('admin/verify-user', data);
        return res.data;
    }
    catch(e) {
        alert(e.response.data.Exception);
        return Promise.reject(e);
    }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
    getVerifiedUsers,
    getWaitingUsers,
    getOrders,
    postVerifyUser
}