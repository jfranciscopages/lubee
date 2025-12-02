<script setup>
const props = defineProps({
    listing: {
        type: Object,
        required: true
    }
});

const emit = defineEmits(["edit", "delete", "view"]);
</script>

<template>
    <div class="card">
        <img :src="listing.images?.[0] || 'https://via.placeholder.com/300x200?text=No+Image'" class="card-img" />

        <div class="card-content">
            <h2>{{ listing.propertyType }} — {{ listing.operationType }}</h2>
            <p class="description">{{ listing.description }}</p>

            <ul class="details">
                <li><strong>Rooms:</strong> {{ listing.rooms }}</li>
                <li><strong>m²:</strong> {{ listing.squareMeters }}</li>
                <li><strong>Age:</strong> {{ listing.age }} years</li>
            </ul>

            <div class="actions">
                <button @click="emit('edit', listing)">Edit</button>
                <button class="danger" @click="emit('delete', listing.id)">Delete</button>
                <button class="btn" @click="$emit('view', listing)">
                    View Details
                </button>

            </div>
        </div>
    </div>
</template>

<style scoped>
.card {
    display: flex;
    flex-direction: column;
    border: 1px solid #ddd;
    border-radius: 10px;
    overflow: hidden;
    background: white;
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.08);
    width: 320px;
}

.card-img {
    width: 100%;
    height: 180px;
    object-fit: cover;
}

.card-content {
    padding: 12px;
}

.description {
    color: #555;
    font-size: 14px;
    margin: 8px 0;
}

.details {
    padding: 0;
    margin: 8px 0;
    list-style: none;
    font-size: 14px;
}

.details li {
    margin-bottom: 4px;
}

.actions {
    display: flex;
    justify-content: space-between;
    margin-top: 10px;
}

button {
    padding: 6px 12px;
    border-radius: 6px;
    cursor: pointer;
    border: none;
    background: #3498db;
    color: white;
}

button.danger {
    background: #e74c3c;
}
</style>
