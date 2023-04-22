<template>
    <div class="help-guarantee">
        <MLoading v-if="showLoading"></MLoading>
        <div class="title-help-guarantee" style="font-weight: 600;">I. CHÍNH SÁCH BẢO HÀNH</div>
        <div class="content-help-guarantee">
            <p>1. Với mỗi chủng loại phụ tùng AutoPro sẽ có một chính sách bảo hành khác nhau. Khách hàng sẽ được cung
                cấp thông tin chi tiết khi nhận hàng.</p>
            <p>2. Với những sản phẩm khách hàng có nhu cầu bảo hành 3 tháng. 6 tháng. 1 năm . 2 năm AutoPro sẽ có những
                mức giá phù hợp với thời gian bảo hành sản phẩm, Vì có rất nhiều khách</p>
            <p>3. hàng và nhiều loại sản phẩm không cần bảo hành thời gian để giảm chi phí giá thành sản phẩm.</p>
            <p>4. AutoPro đảm bảo toàn bộ các sản phẩm bên AutoPro cung cấp đạt đúng tiêu chuẩn , chất lượng như đã
                thống nhất khi báo giá cho khách hàng, để khách hàng có những sự lựa chọn phù hợp với nhu cầu.</p>
        </div>
        <div class="title-help-guarantee" style="font-weight: 600;">II. NHỮNG PHỤ TÙNG KHÔNG NẰM TRONG DANH MỤC BẢO HÀNH
        </div>
        <div class="content-help-guarantee">
            <p>1. Đồ nội thất</p>
            <p>2. Nẹp, ba đờ xốc và những phụ tùng thân vỏ</p>
            <p>3. Gạt mưa</p>
            <p>4. Má phanh hoặc guốc phanh, tang trống phanh hoặc đĩa phanh</p>
            <p>5. Đĩa côn</p>
            <p>6. Chi tiết cao su như ống cao su, dây cuaroa, gioăng cửa</p>
            <p>7. Kính chắn gió</p>
            <p>8. Còi xe</p>
            <p>9. Bugi</p>
            <p>10. Lốp</p>
        </div>
        <p>Mọi thắc mắc Quý khách vui lòng liên hệ đến số điện thoại Hotline <b style="font-weight: 800;">0394061318</b> để
            biết thêm thông tin chi tiết.</p>
        <p>Cảm ơn Quý khách đã sử dụng sản phẩm và dịch vụ của <b style="font-weight: 800;">AutoPro</b> !</p>
    </div>
</template>

<script>
import MLoading from '@/components/MLoading.vue';

export default {
    /**
     * Tên component
     */
    name: 'Guarantee',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { MLoading },
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
            showLoading: false
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
        }, 500);
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {

    }
}
</script>

<style></style>