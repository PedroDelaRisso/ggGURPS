<script lang="ts">
import CampaignList from "./components/Campaign/CampaignList.svelte";
import GameMasterList from "./components/GameMasters/GameMasterList.svelte";
import PlayerList from "./components/Players/PlayerList.svelte";
</script>

<main>
  <GameMasterList />
  <PlayerList />
  <CampaignList />
</main>
