<script lang="ts">
import { createEventDispatcher } from 'svelte';
import Character from '../../models/Character';
import CharacterService from '../../services/CharacterService';
import { Col, Container, Row } from 'sveltestrap';

let character = new Character();

const dispatch = createEventDispatcher();

function createCampaign() {
    dispatch('create-campaign', character);
    CharacterService.create(character);
    character = new Character();
}
</script>
<svelte:head>
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css">
</svelte:head>

<Container>
    <Row>
        <h1>Character Sheet</h1>
    </Row>
    <Row>
        <Col md="1">
            <b>Name</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="text" bind:value={character.name}>
        </Col>
    </Row>
    <Row><h4>Attributes</h4></Row>
    <Row>
        <Col md="1">
            <b>ST:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.strength}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>DX:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.dexterity}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>IQ:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.inteligence}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>HT:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.health}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>HP:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.hitPoints}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>FP:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.fatiguePoints}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>ER:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.energyReserve}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>Will:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.will}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>Perception:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.perception}>
        </Col>
    </Row>
    <Row>
        <Col md="1">
            <b>Magery:</b>
        </Col>
        <Col md="3">
            <input style="width: 100%" type="number" bind:value={character.magery}>
        </Col>
    </Row>
    <Row>
        <Col md="4">
            <button style="width: 100%" on:click={() => createCampaign()}>Create Character</button>
        </Col>
    </Row>
</Container>
