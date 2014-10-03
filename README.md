XRouteTestClient
================

This is a test client for working with PTV xRoute server. It uses PTV xMap server to visualise results, although this is optional.
It serves both as a tool for testing routes and as a show case of the posibilities.

Cuurently it has support for:
- general route calculation
- fuzzy via routing
- ferry via routing
- server profiles
- client profiling
- toll
- dynamic routing
- emmission

General product info: http://xserver.ptvgroup.com/en-uk/products/ptv-xserver/ptv-xroute/

Currently their are 3 branches:

master - latest stable version

1.16.0.0 - written aginst the 1.16 API of the xServer. Only use this for xRoute versions 1.16.0, 1.17.0 and 1.18.0 .

advancedtour - working branch for implementing advanced tour functionality, will be merged with master when finished
