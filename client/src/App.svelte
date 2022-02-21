<script lang="ts">
import { onMount } from "svelte";
import GameMasterList from "./components/GameMasterList.svelte";
import type GameMaster from "./models/GameMaster";
let gameMastersInDb = [];
onMount(async () => {
    await fetch('https://localhost:5001/api/GameMasters')
        .then((response) => response.json())
        .then((data)=> {
            gameMasters = data;
            console.log(data);
        })
});

$: gameMasters = gameMastersInDb;
function deleteGameMaster(e) {
    const itemId = e.detail;
    fetch(`https://localhost:5001/api/GameMasters/${itemId}`, {
        method: 'Delete'
    }).then(() => gameMasters = gameMasters.filter((item) => item.id !== itemId));
}
</script>

<main>
    <GameMasterList {gameMasters} on:delete-gamemaster={deleteGameMaster}/>
</main>