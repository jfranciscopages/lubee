<script setup>
import { onMounted, ref } from "vue";
import * as L from "leaflet";
import "leaflet/dist/leaflet.css";

const props = defineProps({
  listing: Object
});

const emit = defineEmits(["back"]);

const mapContainer = ref(null);
const coords = props.listing.coordinates.split(",").map(c => parseFloat(c));

onMounted(() => {
  const map = L.map(mapContainer.value).setView(coords, 15);

  L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    attribution:
      '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
  }).addTo(map);

  const defaultIcon = L.icon({
    iconUrl: "https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon.png",
    iconRetinaUrl: "https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon-2x.png",
    shadowUrl: "https://unpkg.com/leaflet@1.9.4/dist/images/marker-shadow.png",
    iconSize: [25, 41],
    iconAnchor: [12, 41],
    popupAnchor: [1, -34],
    shadowSize: [41, 41]
  });

  L.marker(coords, { icon: defaultIcon }).addTo(map);
});
</script>

<template>
  <div class="detail-container">
    <button class="back-btn" @click="emit('back')">← Back</button>

    <h2>{{ listing.propertyType }} — {{ listing.operationType }}</h2>
    <p>{{ listing.description }}</p>

    <div class="images">
        <img
            v-for="(img, index) in listing.images.slice(0, 2)"
            :key="index"
            :src="img"
            alt="Property image"
        />
    </div>


    <ul class="details">
      <li><strong>Rooms:</strong> {{ listing.rooms }}</li>
      <li><strong>Area:</strong> {{ listing.squareMeters }} m²</li>
      <li><strong>Age:</strong> {{ listing.age }} years</li>
    </ul>

    <div ref="mapContainer" class="map"></div>
  </div>
</template>

<style scoped>
.detail-container {
  max-width: 800px;
  margin: 20px auto;
  padding: 16px;
}

.back-btn {
  padding: 6px 12px;
  margin-bottom: 16px;
  border: none;
  border-radius: 6px;
  background: #3498db;
  color: white;
  cursor: pointer;
  font-weight: 600;
}

.back-btn:hover {
  background: #2c81bb;
}

.images {
  display: flex;
  flex-wrap: wrap;
  gap: 12px;
  margin-bottom: 16px;
}

.images img {
  width: calc(50% - 6px);
  border-radius: 8px;
  object-fit: cover;
  height: 180px;
}

.details {
  list-style: none;
  padding: 0;
  font-size: 14px;
  margin-bottom: 16px;
}

.details li {
  margin-bottom: 4px;
}

.map {
  height: 400px;
  width: 100%;
  border-radius: 8px;
}
</style>
