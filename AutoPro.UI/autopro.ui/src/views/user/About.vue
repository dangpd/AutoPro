<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="about">
            <TheLineLink name="Giới thiệu"></TheLineLink>
            <div class="about1">
                <div class="title-about">GIỚI THIỆU VỀ AUTOPRO</div>
                <div class="content-about">Công ty TNHH Thiết bị Phụ tùng và Dịch vụ Kỹ thuật AUTOPRO - Đơn vị đầu ngành
                    trong
                    lĩnh vực cung cấp phụ tùng và phụ kiện cho xe hơi Hàn Quốc hàng đầu tại thị trường Việt Nam
                </div>
                <img src="../../assets/Image/logo3.jpg" alt="" style="margin: 20px 300px;">
            </div>
            <div class="about1">
                <div class="title-about">Giới thiệu về AUTOPRO - Hệ thống phụ tùng ô tô chính hãng</div>
                <div class="content-about">Là đơn vị tiên phong với hơn 21 năm kinh nghiệm trong ngành hàng phụ tùng - phụ
                    kiện ô tô, Hệ thống phụ tùng ô tô chính hãng AUTOPRO là đơn vị nhập khẩu và phân phối các sản phẩm
                    phụ tùng thương hiệu KIA, HYUNDAI, GM, MANDO, CTR, PHC VALEO, ILJIN, PHG, SCHAEFFLER… dành cho xe du
                    lịch; các sản phẩm phụ kiện thương hiệu AUTO CLOVER, 365 AUTO, HIPAS, KORIS, COIDO, VOLCANO, CARORI …
                    dành cho xe du lịch, xe tải và xe khách.
                </div>
                <div class="content-about">Phụ tùng ô tô AUTOPRO trực thuộc Công ty TNHH Thiết bị Phụ tùng và Dịch vụ Kỹ
                    thuật
                    AUTOPRO sở hữu kho phụ tùng - phụ kiện ô tô lớn nhất miền Bắc (1.800 m2 x 3 tầng), kho hàng của chúng
                    tôi
                    luôn sẵn sàng với trên 40.000 mặt hàng phụ tùng dành cho các model xe du lịch thông dụng của các hãng
                    Kia, Hyundai...; trên 4.000 mặt hàng phụ kiện thông dụng dành cho các loại xe du lịch, xe tải, xe khách
                    Hàn Quốc, Nhật Bản, Mỹ…
                </div>
                <div class="content-about">Chúng tôi tự hào là đơn vị đứng tốp đầu thị trường Việt Nam với hơn 1.000 đại lý
                    chính thức, hơn 10.000 Khách hàng trải khắp 64 tỉnh thành trên cả nước. Chúng tôi cam kết luôn cung cấp
                    những sản phẩm và dịch vụ tốt nhất, đúng như Sứ mệnh và Giá trị cốt lõi mà chúng tôi đã đề ra:</div>
            </div>
            <div class="about1">
                <div class="title-about">Sứ mệnh</div>
                <div class="content-about">Luôn là đối tác tin cậy, đồng hành và phát triển cùng với khách hàng trong lĩnh
                    vực phụ tùng - phụ kiện ô tô nhờ khả năng cung cấp tốt nhất các sản phẩm có chất lượng với giá cả hợp lý
                    và dịch vụ bảo hành - hậu mãi chuyên nghiệp.
                </div>
            </div>
            <div class="about1">
                <div class="title-about">Tầm nhìn
                </div>
                <div class="content-about">Trở thành thương hiệu hàng đầu Việt Nam trong ngành hàng phụ tùng, phụ kiện ô tô.
                </div>
            </div>
            <div class="about1">
                <div class="title-about">Giá trị cốt lõi
                </div>
                <div class="content-about">TÂM: AUTOPRO luôn lấy chữ TÂM để phục vụ Khách hàng, Đối tác
                </div>
                <div class="content-about">TÍN: AUTOPRO luôn lấy chữ TÍN để xây dựng thương hiệu và bảo vệ chữ TÍN như bảo
                    vệ tính mạng của chính mình</div>
                <div class="content-about">NHÂN: AUTOPRO luôn lấy chữ NHÂN để tạo dựng doanh nghiệp phát triển bền vững và
                    trường tồn</div>
            </div>
            <div class="about1">
                <div class="title-about"></div>
                <div class="content-about">
                    Với phương châm cùng hợp tác - cùng phát triển bền vững, chúng tôi cam kết luôn mang đến cho Quý Đối
                    tác: CHẤT LƯỢNG TỐT NHẤT - GIÁ CẢ HỢP LÝ NHẤT - DỊCH VỤ TỐT NHẤT. Chúng tôi rất tin tưởng vào sự thành
                    công tốt đẹp và lâu dài trong quá trình hợp tác giữa chúng tôi và Quý Khách hàng - Quý Đối tác.
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
    name: 'About',
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
@import url(../../css/about.css);
</style>