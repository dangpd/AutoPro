import base from "./baseService";
class OrderService extends base {
    getAll() {
        let urlMain = `${this.getBaseService()}Orders`;
        return urlMain;
    }

    getOrderByID(id) {
        return `${this.getAll()}/${id}`;
    }

    addOrder() {
        return `${this.getAll()}/`
    }

    updateOrder(id) {
        return `${this.getAll()}/${id}`;
    }

    deleteOrderByID(id) {
        return `${this.getAll()}/${id}`;
    }

    getOrderDeatilByID(id){
        return `${this.getAll()}/getOrderDetail/${id}`;
    }

    filterOrder(key = '', pageSize, pageNumber) {
        return `${this.getAll()}/Filter?textSearch=${key}&pageSize=${pageSize}&pageNumber=${pageNumber}`;
    }
}

const ApiOrder = new OrderService();
export default ApiOrder;