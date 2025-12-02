const BASE_URL = "http://localhost:5151/api/listing";

export async function getListings() {
  const res = await fetch(BASE_URL);
  return res.json();
}

export async function getListing(id) {
  const res = await fetch(`${BASE_URL}/${id}`);
  return res.json();
}

export async function createListing(listing) {
  const payload = { ...listing };
  delete payload.id;

  const res = await fetch(BASE_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(payload),
  });

  if (!res.ok) {
    throw new Error("Failed to create listing");
  }

  return await res.json();
}



export async function updateListing(id, listing) {
  await fetch(`${BASE_URL}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(listing),
  });
}

export async function deleteListing(id) {
  await fetch(`${BASE_URL}/${id}`, {
    method: "DELETE",
  });
}
