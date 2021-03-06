﻿/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    // #region Constructor

    angular.module('tedushop.application_groups', ['tedushop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    // #endregion

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
        .state('application_groups', {
            url: "/application_groups",
            parent: 'base',
            templateUrl: "/app/components/application_groups/applicationGroupListView.html",
            controller: "applicationGroupListController"
        })
        .state('add_application_group', {
            url: "/add_application_group",
            parent: 'base',
            templateUrl: "/app/components/application_groups/applicationGroupAddView.html",
            controller: "applicationGroupAddController"
        })
        .state('edit_application_group', {
            url: "/edit_application_group/:id",
            parent: 'base',
            templateUrl: "/app/components/application_groups/applicationGroupEditView.html",
            controller: "applicationGroupEditController"
        })
    }
})();