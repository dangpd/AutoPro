<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Hệ thống gầm phanh"></TheLineLink>
            <div class="products-category">
                <div class="product-category-filter">
                    <div class="product-category-filter-header">Bộ lọc</div>
                    <div style="display: flex;align-items: center;">
                        Sắp xếp theo:
                        <MSelectBoxDown :data="[
                            { feildShow: 'Ngày tạo gần nhất', feildValue: 'p.createdDate DESC' },
                            { feildShow: 'Ngày sửa gần nhất', feildValue: 'p.modifiedDate DESC' },
                            { feildShow: 'Theo giá tăng dần', feildValue: 'p.price ASC' },
                            { feildShow: 'Theo giá giảm dần', feildValue: 'p.price DESC' },
                            { feildShow: 'Tên sản phẩm a-z', feildValue: 'p.productName ASC' },
                            { feildShow: 'Tên sản phẩm z-a', feildValue: 'p.productName DESC' },
                        ]" v-model="orderBy"></MSelectBoxDown>
                    </div>
                    Lọc giá
                    <div class="product-category-apply">
                        <button>Áp dụng</button>
                    </div>
                </div>
                <div class="product-category-content">
                    <div class="product-category-title">Danh sách sản phẩm tìm được</div>
                    <div class="list-product-category">
                        <div v-for="(item, index) in dataSearch" :key="index"
                            :class="{ 'row-selected': rowSelected == item.productID }">
                            <div>
                                <div class="product">
                                    <div class="product-image">
                                        <img :src="item.image" alt="">
                                        <div class="favourtive" @click="favoriteProduct(ỉtem)">
                                            <i class="fa-solid fa-heart"></i>
                                        </div>
                                    </div>
                                    <div class="product-name" style="font-size: 15px;">{{ item.productName }}</div>
                                    <div class="price">{{ formatMoney(item.price) }}</div>
                                    <div class="product-buttom">
                                        <div class="product-detail" @click="detailProduct(item.productID)">Xem chi tiết
                                        </div>
                                        <div class="add-cart" @click="addCart(item)">Thêm vào giỏ hàng</div>
                                    </div>
                                </div>
                                <!-- </router-link> -->
                            </div>
                        </div>
                    </div>
                    <div class="see-more" @click="seeMoreImported">Xem thêm</div>
                </div>
            </div>
        </div>
        <TheFooter></TheFooter>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>

<script>
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import MCombobox from '@/components/MCombobox.vue'
import MLoading from '@/components/MLoading.vue';
import enumAUTO from '../../js/gEnum';
import axios from 'axios';
import { formatMoney } from '@/js/gCommon';
import MSelectBoxDown from '@/components/MSelectBoxDown.vue';

export default {
    /**
         * Tên component
         */
    name: 'ProdctByCategory',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, TheLineLink, MCombobox, MLoading, MSelectBoxDown },
    /**
     * Emit sự thay đổi
     */
    emits: [""],
    directives: {

    },
    /**
     * Data
     */
    data() {
        return {
            showLoading: false,
            listFilter: [],
            orderBy: 'p.modifiedDate DESC',
            pageIndex: 1,
            pageSize: 8,
            dataSearch: {},
            rowSelected: -1,
        }
    },
    /**
     * Phương thức
     */
    methods: {
        formatMoney(money) {
            return formatMoney(money);
        },

        getAllBrand() {
            axios.get(ApiBrand.getAll())
                .then((res) => {
                    if (res.status == 200) {
                        this.dataBrand = res.data;
                    } else {
                        this.dataBrand = null;
                    }
                })
        },
        getValue() {
            this.listFilter = [
                {
                    FieldName: "ProductCode",
                    Operator: enumAUTO.Operator.Like,
                    FilterValue: this.$store.state.search,
                },
                {
                    FieldName: "ProductName",
                    Operator: enumAUTO.Operator.Like,
                    FilterValue: this.$store.state.search,
                },
                {
                    FieldName: "PlaceOrigin",
                    Operator: enumAUTO.Operator.Like,
                    FilterValue: this.$store.state.search,
                },
                // {
                //     FieldName: "branchid",
                //     Operator: enumAUTO.Operator.Equal,
                //     FilterValue: this.$store.state.search,
                // },
            ];
            this.getDataRes();
        },

        getDataRes() {
            this.showLoading = true;
            setTimeout(() => {
                let objectFilter = {
                    pageIndex: this.pageIndex,
                    pageSize: this.pageSize,
                    listFilter: this.listFilter,
                    listOrderBy: this.orderBy
                }
                console.log(objectFilter);
                axios.post("https://localhost:7129/api/v1/Product/PagingProductByFilter", objectFilter)
                    .then((res) => {
                        if (res.status == 200) {
                            this.showLoading = false;
                            this.dataSearch = res.data.data;
                            console.log(res);
                        }
                    })
            }, 500);
        },

        seeMoreImported() {
            this.pageSize = this.pageSize + 8;
            this.getValue();
        },

        detailProduct(item) {
            this.$router.push({ name: 'product', params: { id: item } });
        },

        addCart(data) {
            this.productCart = data;
            this.productCart.quantitys = this.number;
            // console.log(this.productCart);
            this.$store.commit('addToCart', this.productCart);
        },

        favoriteProduct(data) {
            if (!this.role) {
                alert("Bạn chưa đăng nhập");
            } else {
                this.productFavorite = data;
                this.$store.commit('addToCart', this.productFavorite);
            }
        }
    },
    created() {
        this.getValue();
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {
        '$route.params.key': function (newVal) {
            this.getValue();
        },

        orderBy(newVal) {
            this.orderBy = newVal;
            this.getValue();
        },

        // listFilter(newVal){
        //     this.orderBy = newVal;
        //     this.getValue();
        // }
    }
}
</script>

<style>
@import url(../../css/productcategory.css);
</style>