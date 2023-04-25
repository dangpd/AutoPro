<template>
    <div class="aform-detail">
        <div class="aform-account">
            <div class="aform-title">
                <div class="aform-title-left">
                    {{ this.title }}
                </div>
                <div class="onClose" @click="onClose">
                    <i class="fa-regular fa-circle-xmark"></i>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Mã danh mục :
                    </div>
                    <MInput type="text" v-model="category.categoryCode"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MInput>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Tên danh mục :
                    </div>
                    <MInput type="text" v-model="category.categoryName"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Mô tả :
                    </div>
                    <MInput type="text" v-model="category.description"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MInput>
                </div>
            </div>
            <div class="aformSave" @click="saveCategory">
                <button>Lưu</button>
            </div>
        </div>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
import MLoading from '@/components/MLoading.vue';
import Resource from '../../js/gResource';
import axios from 'axios';
import ApiProductCategory from '../../js/apiProductCategory';
export default {
    /**
     * Tên component
     */
    name: "AdminCategoryDetail",
    /**
     * Hứng nhận
     */
    props: ["id", "type"],
    /**
     * Component được sử dụng
     */
    components: { MInput, MLoading },
    /**
     * Emit sự thay đổi
     */
    emits: ["onClose", "success"],
    directives: {},
    /**
     * Data
     */
    data() {
        return {
            showLoading: false,
            category: {},
            title: '',
        };
    },
    /**
     * Phương thức
     */
    methods: {
        onClose() {
            this.$emit("onClose");
        },

        async saveCategory() {
            if (this.type == Resource.FormAdminType.Add) {
                await axios.post(ApiProductCategory.addProductCategory(), this.category)
                    .then((res) => {
                        if (res.status == 201) {
                            this.$emit("onClose");
                            this.$emit("success");
                        }
                    })
                    .catch((err) => {
                        console.log(err);
                    })
            } else {
                await axios.put(ApiProductCategory.updateProductCategory(this.id), this.category)
                    .then((res) => {
                        if (res.status == 200) {
                            this.$emit("success");
                            this.$emit("onClose");
                        }
                    })
                    .catch((err) => {
                        console.log(err);
                    })
            }
        }
    },
    created() {
        // Khởi tạo lấy giá trị id truyền vào
        if (this.id) {
            // Bật loadding
            this.showLoading = true;
            setTimeout(() => {
                this.title = Resource.TitleFormAdmin.UpdateCategory;
                //Lấy dữ liệu
                axios.get(ApiProductCategory.getProductCategoryByID(this.id))
                    .then((res) => {
                        this.showLoading = false;
                        this.category = res.data;
                        // this.srcImage = res.data.image;
                        // this.ImageNone = true;
                        // console.log(this.srcImage);
                    })
            }, 500)
        } else {
            this.title = Resource.TitleFormAdmin.AddCategory;
        }
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {},
};
</script>
  
<style>
@import url(../../css/admin/adminaccount.css);
</style>