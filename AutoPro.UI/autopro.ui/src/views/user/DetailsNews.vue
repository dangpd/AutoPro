<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Tin tức" detail="/ Chi tiết tin tức"></TheLineLink>
                <div class="details-news-title">Tiêu đề tin tức</div>
                <div class="details-news-time">Thời gian</div>
                <div class="details-news-image">
                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                </div>
                <div class="details-news-content">Chi tiết nội dung</div>
        </div>
        <TheFooter></TheFooter>
    </div>
</template>

<script>
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import TheNavbar from '@/layout/TheNavbar.vue';

export default {
    /**
     * Tên component
     */
    name: 'DetailsNews',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, TheLineLink },
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

        }
    },
    /**
     * Phương thức
     */
    methods: {

    },
    created() {

    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {

    }
}
</script>

<style>
@import url(../../css/detailsnews.css);
</style>