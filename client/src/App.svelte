<script lang="ts">
import { onMount } from "svelte";
import GameMasterForm from "./components/GameMasterForm.svelte";
import GameMasterItem from "./components/GameMasterItem.svelte";
import GameMasterList from "./components/GameMasterList.svelte";
import GameMaster from "./models/GameMaster";
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

function createGameMaster(e) {
    const gm = new GameMaster();
    gm.name = e.detail;
    console.log(gm);
    fetch(`https://localhost:5001/api/GameMasters`, {
        method: 'Post',
        body: JSON.stringify(gm),
        headers: {
            "content-type": "application/json",
        },
    });
}
</script>

<main>
    <GameMasterForm on:create-gamemaster={createGameMaster} />
    <GameMasterList {gameMasters} on:delete-gamemaster={deleteGameMaster}/>
</main>