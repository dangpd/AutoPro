<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <MLoading v-if="showLoading"></MLoading>
            <TheLineLink name="Hệ thống gầm phanh"></TheLineLink>
            <div class="products-category">
                <div class="product-category-filter">
                    <div class="product-category-filter-header">Bộ lọc</div>
                    <MCombobox></MCombobox>
                    Lọc giá
                    <div class="product-category-apply">
                        <button>Áp dụng</button>
                    </div>
                </div>
                <div class="product-category-content">
                    <div class="product-category-title">Danh sách sản phẩm</div>
                    <div class="list-product-category">
                        <router-link to="/product/:id" style="text-decoration: none;color: black;">
                            <div class="product-category">
                                <div class="product-category-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                    <div class="favourtive">
                                        <i class="fa-solid fa-heart"></i>
                                    </div>
                                </div>
                                <div class="product-category-name">Lốc gió</div>
                                <div class="product-category-price">Giá : 330.000Vnd</div>
                                <div class="product-category-buttom">
                                    <div class="product-category-detail">Xem chi tiết</div>
                                    <div class="product-category-cart">Thêm vào giỏ hàng</div>
                                </div>
                            </div>
                        </router-link>
                        <router-link to="/product/:id" style="text-decoration: none;color: black;">
                            <div class="product-category">
                                <div class="product-category-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                    <div class="favourtive">
                                        <i class="fa-solid fa-heart"></i>
                                    </div>
                                </div>
                                <div class="product-category-name">Lốc gió</div>
                                <div class="product-category-price">Giá : 330.000Vnd</div>
                                <div class="product-category-buttom">
                                    <div class="product-category-detail">Xem chi tiết</div>
                                    <div class="product-category-cart">Thêm vào giỏ hàng</div>
                                </div>
                            </div>
                        </router-link>
                        <router-link to="/product/:id" style="text-decoration: none;color: black;">
                            <div class="product-category">
                                <div class="product-category-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                    <div class="favourtive">
                                        <i class="fa-solid fa-heart"></i>
                                    </div>
                                </div>
                                <div class="product-category-name">Lốc gió</div>
                                <div class="product-category-price">Giá : 330.000Vnd</div>
                                <div class="product-category-buttom">
                                    <div class="product-category-detail">Xem chi tiết</div>
                                    <div class="product-category-cart">Thêm vào giỏ hàng</div>
                                </div>
                            </div>
                        </router-link>
                        <router-link to="/product/:id" style="text-decoration: none;color: black;">
                            <div class="product-category">
                                <div class="product-category-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                    <div class="favourtive">
                                        <i class="fa-solid fa-heart"></i>
                                    </div>
                                </div>
                                <div class="product-category-name">Lốc gió</div>
                                <div class="product-category-price">Giá : 330.000Vnd</div>
                                <div class="product-category-buttom">
                                    <div class="product-category-detail">Xem chi tiết</div>
                                    <div class="product-category-cart">Thêm vào giỏ hàng</div>
                                </div>
                            </div>
                        </router-link>
                    </div>
                    <div class="see-more">Xem thêm</div>
                </div>
            </div>
        </div>
        <TheFooter></TheFooter>
    </div>
</template>

<script>
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import MCombobox from '@/components/MCombobox.vue'
import MLoading from '@/components/MLoading.vue';

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
    components: { TheHeader, TheNavbar, TheFooter, TheLineLink, MCombobox, MLoading },
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
        }
    },
    /**
     * Phương thức
     */
    methods: {

    },
    created() {
        this.showLoading = true;
        setTimeout(async () => {
            this.showLoading = false;
        }, 1000);
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {
        
    }
}
</script>

<style>
@import url(../../css/productcategory.css);
</style>