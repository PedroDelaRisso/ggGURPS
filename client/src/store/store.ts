import { writable, derived } from "svelte/store";

export const apiData = writable([]);

export const gameMasters = derived(apiData, ($apiData) => {
    return $apiData.map((gm) => gm.name);
})