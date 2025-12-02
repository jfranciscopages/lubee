<script setup>
import { ref, watch, computed } from "vue";
import { createListing, updateListing } from "../api/listings.js";

const props = defineProps({
  listing: {
    type: Object,
    default: null
  }
});

const emit = defineEmits(["back"]);

const form = ref({
  id: null,
  propertyType: "",
  operationType: "",
  description: "",
  rooms: 0,
  squareMeters: 0,
  age: 0,
  coordinates: "",
  images: []
});

watch(
  () => props.listing,
  (l) => {
    if (l) {
      form.value = { ...l };
    } else {
      form.value = {
        id: null,
        propertyType: "",
        operationType: "",
        description: "",
        rooms: 0,
        squareMeters: 0,
        age: 0,
        coordinates: "",
        images: []
      };
    }
  },
  { immediate: true }
);

const isEditing = computed(() => props.listing !== null);

async function save() {
  if (isEditing.value) {
    await updateListing(form.value.id, form.value);
  } else {
    await createListing(form.value);
  }

  emit("back");
}


</script>

<template>
  <div class="form-wrapper">
    <div class="form-card">

      <h2>{{ isEditing ? "Edit Listing" : "Create Listing" }}</h2>
      <p class="subtitle">
        {{ isEditing ? "Update the listing information" : "Fill out the form to create a new property listing." }}
      </p>

      <form @submit.prevent="save" class="grid">

        <div class="field">
          <label>Property Type</label>
          <input v-model="form.propertyType" placeholder="e.g. Apartment" />
        </div>

        <div class="field">
          <label>Operation Type</label>
          <input v-model="form.operationType" placeholder="e.g. Rent / Sale" />
        </div>

        <div class="field full">
          <label>Description</label>
          <textarea v-model="form.description" placeholder="Write a short description..." />
        </div>

        <div class="field">
          <label>Rooms</label>
          <input type="number" v-model.number="form.rooms" min="0" />
        </div>

        <div class="field">
          <label>Square Meters</label>
          <input type="number" v-model.number="form.squareMeters" min="0" />
        </div>

        <div class="field">
          <label>Age</label>
          <input type="number" v-model.number="form.age" min="0" />
        </div>

        <div class="field full">
          <label>Coordinates</label>
          <input v-model="form.coordinates" placeholder="-34.6037, -58.3816" />
        </div>

        <div class="actions full">
          <button type="submit" class="btn primary">
            {{ isEditing ? "Save Changes" : "Create Listing" }}
          </button>

          <button
            type="button"
            class="btn secondary"
            @click="emit('back')"
          >
            Back
          </button>
        </div>

      </form>
    </div>
  </div>
</template>

<style scoped>

.form-wrapper {
  display: flex;
  justify-content: center;
  padding: 40px 20px;
}

.form-card {
  width: 100%;
  max-width: 550px;
  background: white;
  padding: 28px;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.1);
}

h2 {
  margin: 0 0 6px 0;
  font-size: 24px;
  font-weight: 600;
}

.subtitle {
  font-size: 14px;
  color: #555;
  margin-bottom: 24px;
}

.grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 16px;
}

.full {
  grid-column: span 2;
}

.field {
  display: flex;
  flex-direction: column;
}

label {
  font-size: 14px;
  margin-bottom: 6px;
  color: #333;
}

input,
textarea {
  border: 1px solid #ccc;
  padding: 10px;
  border-radius: 8px;
  font-size: 15px;
  outline: none;
  background: #fafafa;
  transition: border-color 0.2s;
}

input:focus,
textarea:focus {
  border-color: #3498db;
  background: white;
}

textarea {
  min-height: 80px;
  resize: vertical;
}

.actions {
  display: flex;
  gap: 12px;
  margin-top: 10px;
}

.btn {
  flex: 1;
  padding: 12px 0;
  border-radius: 8px;
  cursor: pointer;
  font-size: 15px;
  border: none;
  transition: 0.2s;
}

.primary {
  background: #3498db;
  color: white;
}

.primary:hover {
  background: #2c81bb;
}

.secondary {
  background: #e0e0e0;
}

.secondary:hover {
  background: #c8c8c8;
}

@media (max-width: 600px) {
  .grid {
    grid-template-columns: 1fr;
  }
  .full {
    grid-column: span 1;
  }
}
</style>
