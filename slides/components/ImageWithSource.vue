<script setup>
import { ref } from "vue";

const props = defineProps({
  src: {
    required: true,
  },
  alt: {
    required: true,
  },
  source: {
    default: "",
  },
  height: {
    default: "h-xs"
  }
});

const src = ref(props.src);
const alt = ref(props.alt);
const source = ref(props.source);
const height = ref(props.height);
</script>

<template>
  <div v-bind:class="height" class="p-2">
    <img :src="src" v-bind:alt="alt" class="object-contain h-full" />
    <span class="absolute ml-4 italic text-xs" style="bottom: 8%; ">
      {{ source }}
    </span>
  </div>
</template>



      
  
