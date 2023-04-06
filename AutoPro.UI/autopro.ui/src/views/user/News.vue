<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Tin tức"></TheLineLink>
            <div class="content-news">
                <div class="nav-list-news">
                    <div class="title-news">TIN TỨC</div>
                    <div class="list-content">
                        <div class="news">
                            <div class="news-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="news-right">
                                <div class="news-title">Tiêu để tin tức</div>
                                <div class="news-time">Thời gian tin tức</div>
                                <div class="news-content">Nội dung tin tức</div>
                            </div>
                        </div>
                        <div class="news">
                            <div class="news-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="news-right">
                                <div class="news-title">Tiêu để tin tức</div>
                                <div class="news-time">Thời gian tin tức</div>
                                <div class="news-content">Nội dung tin tức</div>
                            </div>
                        </div>
                        <div class="news">
                            <div class="news-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="news-right">
                                <div class="news-title">Tiêu để tin tức</div>
                                <div class="news-time">Thời gian tin tức</div>
                                <div class="news-content">Nội dung tin tức</div>
                            </div>
                        </div>
                    </div>
                    <div class="see-more">Xem thêm</div>
                </div>
                <div class="new-news">
                    <div class="title-news" style="padding-left: 10px;">BÀI VIẾT MỚI NHẤT</div>
                    <div class="list-news-new">
                        <div class="news-new">
                            <div class="news-new-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="news-new-right">
                                <div class="news-new-title">Tiêu để tin tức</div>
                                <div class="news-new-time">Thời gian tin tức</div>
                            </div>
                        </div>
                        <div class="news-new">
                            <div class="news-new-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="news-new-right">
                                <div class="news-new-title">Tiêu để tin tức</div>
                                <div class="news-new-time">Thời gian tin tức</div>
                            </div>
                        </div>
                        <div class="news-new">
                            <div class="news-new-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="news-new-right">
                                <div class="news-new-title">Tiêu để tin tức</div>
                                <div class="news-new-time">Thời gian tin tức</div>
                            </div>
                        </div>
                    </div>
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

export default {
    /**
     * Tên component
     */
    name: 'News',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheLineLink, TheFooter },
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
@import url(../../css/news.css);
</style>