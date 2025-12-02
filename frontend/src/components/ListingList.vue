<script setup>
import { ref, onMounted } from "vue";
import { getListings, deleteListing } from "../api/listings.js";
import ListingCard from "./ListingCard.vue";

const listings = ref([]);

async function loadListings() {
  listings.value = await getListings();
}

async function removeListing(id) {
  await deleteListing(id);
  await loadListings();
}

onMounted(loadListings);

const emit = defineEmits(["edit"]);
</script>

<template>
  <div class="header">
    <h2>Listings</h2>
    <button class="create-btn" @click="console.log('CLICK'); emit('edit', null)">+ Create new listing</button>
  </div>

  <div class="grid">
    <ListingCard
      v-for="listing in listings"
      :key="listing.id"
      :listing="listing"
      @edit="emit('edit', $event)"
      @delete="removeListing"
      @view="emit('view', $event)"
    />
  </div>
</template>

<style scoped>
.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 16px;
}

.create-btn {
  padding: 8px 14px;
  border: none;
  border-radius: 6px;
  background: #2ecc71;
  color: white;
  cursor: pointer;
}

.grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  justify-content: center;
  gap: 16px;
}

@media (max-width: 1200px) {
  .grid {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (max-width: 600px) {
  .grid {
    grid-template-columns: 1fr;
  }
}



</style>
