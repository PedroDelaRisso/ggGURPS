<script lang="ts">
import { getAllContexts, onMount } from "svelte";
import GameMasterItem from "./GameMasterItem.svelte";
import GameMasterService from "../services/GameMasterService";
import GameMasterForm from "./GameMasterForm.svelte";
import IGameMaster from "../models/GameMaster";
import GameMaster from "../models/GameMaster";

const gameMasterService = new GameMasterService();

let gameMastersInDb = [];
async function getAllGameMasters() {
    gameMastersInDb = await gameMasterService.GetAll();
}
onMount(async () => {
    await getAllGameMasters();
});

async function deleteGameMaster(e) {
    const id = e.detail;
    await gameMasterService.Remove(id).then(() => getAllGameMasters());
}

async function editGameMaster(e) {
    const gameMaster = e.detail;
    await gameMasterService.Edit(gameMaster.id, gameMaster).then(() => getAllGameMasters());
}


async function createGameMaster(e) {
    const gameMaster = new GameMaster();
    gameMaster.name = e.detail;
    await gameMasterService.Create(gameMaster).then(() => getAllGameMasters());
}
$: gameMasters = gameMastersInDb;
</script>
<GameMasterForm on:create-gamemaster={createGameMaster}/>
<h1>GameMaster List</h1>
{#if gameMastersInDb?.length}
    {#each gameMastersInDb as gameMaster (gameMaster.id)}
        <GameMasterItem
            {gameMaster}
            on:delete-gamemaster={deleteGameMaster}
            on:edit-gamemaster={editGameMaster}
        />
    {/each}
{/if}