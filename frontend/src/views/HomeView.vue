<script setup>
import { ref } from "vue";
import ListingList from "../components/ListingList.vue";
import ListingForm from "../components/ListingForm.vue";
import ListingDetail from "@/components/ListingDetail.vue";

const showForm = ref(false);
const selectedListing = ref(null);
const selectedDetail = ref(null);

function startEdit(listing) {
  selectedListing.value = listing;
  showForm.value = true;
}

function startDetail(listing){
  selectedDetail.value = listing;
}

function backToList() {
  showForm.value = false;
  selectedListing.value = null;
  selectedDetail.value = null;
}
</script>

<template>
<div class="home-container">
  <ListingList 
    v-if="!showForm && !selectedDetail"
    @edit="startEdit"
    @view="startDetail"
  />

  <ListingForm 
    v-else-if="showForm"
    :listing="selectedListing"
    @back="backToList"
  />

  <ListingDetail
    v-else
    :listing="selectedDetail"
    @back="backToList"
  />
</div>

</template>

<style scoped>
.home-container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 24px;
}
</style>
