## Endless runner

### Unity version: 2020.3.22f1

[Classroom](https://classroom.google.com/u/2/c/NDMyODE2MzMxNzky/a/NDQzMzU1Mjc1NjI2/details)

[Homeworks](https://mega.nz/file/8p1WkKCZ#A8-EQJq6pvmOkuNbb6ecuveq2p7KXDH_vU_ymk6Gvs8)

[Fonte](https://www.youtube.com/watch?v=CmuAAf1mhiY)

````
Proposta:
"Genere: HyperCasual

Meccaniche:
Simil endless runner.
Il giocatore controlla un personaggio all’interno di una mappa dove, randomicamente, vengono piazzati ostacoli e collezionabili.
I collezionabili possono dare effetti temporanei come: velocità doppia, invincibilità e altro.
Viene dato un punteggio finale in base alla distanza percorsa dal giocatore."

Risposta del prof:
"La proposta va bene, buon lavoro"
````

# Fondamentali
- è anche mobile
- pseudo endless runner

## Sistema Off Game
#### Fra
- menù di pausa
- menù iniziale, bottone Play
- salvataggi
- classifiche single player, miglior punteggio 
- HUD: numero monete raccolte, punteggio, moltiplicatore, vite, potenziamenti attivi permanenti e non
- cambio skin personaggio
- menù con scelta di 3 augment in game
- menù shop ingame
- schermata di fine gioco, con recap del punteggio, monete ottenute e totali
- opzioni con suono, lingua..

## Suoni
#### Michele
- cercare il tipo di suono
- applicare ogni suono ad ogni oggetto:
		moneta acquisita, danno, salto, selezione, ogni click del menù

## Animazione e Modelli
#### Michele
- gestione corretta delle animazioni del personaggio

## Sistema Movimento e Ostacoli
#### Riccardo 
- creazione spawn randomico ostacoli e monete

## Background
#### Riccardo e Gabriel
- 3 stili: foresta, città e planetario
- due corridoi affianco alla strada procedurali che fanno da sfondo 

## Gameplay
#### Gabriel
- l'obbiettivo non è tanto arrivare alla fine quanto fare il punteggio più alto
- limitato a livelli

## Sistema Oggetti
#### Gabriel
- possibilità di trovare durante la strada degli shop che interrompono il gioco e ti permettono di acquistare potenziamenti temporanei e non
- ogni avanzamento di stage ottieni un potenziamento unico e permanente
	tra cui agginuge vite, ad ogni colpo preso raddoppi il punteggio, aumenti la velocità
- trovi monete durante il gioco
- trovi delle strutture che ti danno potenziamenti o debuff permanenti
- variabili in game che cambiano lo stato del personaggio
