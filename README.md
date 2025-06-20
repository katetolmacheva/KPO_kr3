# Система микросервисов для электронной коммерции

Этот проект представляет собой распределенную систему, разработанную для управления **заказами** и **платежами** в рамках интернет-магазина. Архитектура построена на принципах микросервисов, что обеспечивает высокую масштабируемость, гибкость и отказоустойчивость.

## Ключевые компоненты системы:

Система состоит из трех основных микросервисов:

* **API Gateway**: Единая точка входа для всех клиентских запросов. Отвечает за маршрутизацию запросов к соответствующим внутренним сервисам.
* **Order Service**: Обрабатывает все операции, связанные с заказами. Включает в себя функциональность для:
    * **Создания заказа**: Асинхронно инициирует процесс оплаты.
    * **Просмотра списка заказов**: Отображает все существующие заказы пользователя.
    * **Просмотра статуса заказа**: Предоставляет актуальную информацию о статусе конкретного заказа.
* **Payment Service**: Управляет финансовыми операциями и счетами пользователей. Предоставляет следующие возможности:
    * **Создание счета**: Пользователь может иметь только один счет.
    * **Пополнение счета**: Добавление средств на баланс.
    * **Просмотр баланса счета**: Отображение текущего остатка средств.

## Требования к запуску:

Для локального развертывания и запуска системы необходимы:

* **.NET 8 SDK**
* **Docker Compose**

## Инструкции по запуску:

1.  **Сборка и запуск контейнеров:**
    Выполните команду в корневой директории проекта:
    ```bash
    docker-compose up --build
    ```
2.  **Доступ к API Order Service:**
    После запуска контейнеров API для работы с заказами будет доступен по адресу:
    [http://localhost:8080/swagger](http://localhost:8080/swagger)
3.  **Доступ к API Payment Service:**
    API для работы с платежами будет доступен по адресу:
    [http://localhost:8081/swagger](http://localhost/8081/swagger)
4.  **Идентификация пользователя:**
    Для взаимодействия с функционалом сервисов требуется указывать **`userId`**.