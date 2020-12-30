<template>
  <div class="product-component col-3 card">
    <div class="card text-left">
      <img class="card-img-top" src="holder.js/100px180/" alt="">
      <div class="card-body">
        <h4 class="card-title">
          Title
        </h4>
        <p class="card-text">
          Body
        </p>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'ProductComponent',
  props: {
    productProp: {
      type: Object,
      required: true,
      default: () => {
        alert('Product property does not exist.')
      }
    }
  },
  setup(props) {
    return {
      product: computed(() => props.productProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
