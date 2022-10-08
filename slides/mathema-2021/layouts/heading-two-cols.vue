<!--
  Usage:
```md
---
layout: heading-two-cols
---
## Header

::left::
This shows on the left

::right::
# Right
This shows on the right
```
-->

<script setup lang="ts">
const props = defineProps({
  class: {
    type: String,
  },
})
</script>

<template>
  <div class="slidev-layout heading-two-cols w-full">
    <slot />
    
    <div class="two-columns grid grid-cols-2">
      <div class="col-left" :class="props.class">
        <slot name="left" />
      </div>
      <div class="col-right" :class="props.class">
        <slot name="right" />
      </div>
    </div>
  </div>

</template>