/* putil-taskqueue
 ------------------------
 (c) 2017-present Panates
 This library may be freely distributed under the MIT license.
 For details and documentation:
 https://github.com/panates/putil-taskqueue
 */

/**
 * Module dependencies.
 * @private
 */

const EventEmitter = require('events').EventEmitter;
const DoublyLinked = require('doublylinked');

/**
 *
 * @class
 */
class TaskQueue extends EventEmitter {
  /**
   *
   * @param {Object} [options]
   * @param {int} [options.maxQueue]
   * @constructor
   */
  constructor(options) {
    super();
    this._queue = new DoublyLinked();
    this.maxQueue = options && options.maxQueue;
    this.paused = false;
  }

  /**
   *
   * @return {int}
   */
  get size() {
    return this._queue.length + (this._taskRunning ? 1 : 0);
  }

  /**
   *
   */
  pause() {
    this.paused = true;
  }

  /**
   *
   */
  resume() {
    this.paused = false;
    setImmediate(() => this._next());
  }

  /**
   *
   * @param {Function} task Adds new task to the execute queue
   * @param {boolean} [first] Adds new task to first location in queue
   * @return {Promise}
   */
  enqueue(task, first) {
    return new Promise((resolve, reject) => {
      if (this.maxQueue && this.size >= this.maxQueue)
        throw new Error('Queue limit exceeded');
      this.emit('enqueue', task);
      const executor = () => {
        let resolved;
        const handleCallback = (err, result) => {
          /* istanbul ignore next */
          if (resolved) return;
          resolved = true;
          this._taskRunning = null;
          if (err) {
            reject(err);
            if (this.listenerCount('error') > 0)
              this.emit('error', err);
          } else {
            this.emit('task-complete', task);
            resolve(result);
          }
          if (!this._queue.length)
            this.emit('finish');
          else
            setImmediate(() => this._next());
        };
        try {
          const o = task(handleCallback);
          if (task.length === 0) {
            if (typeof o === 'object' && typeof o.then === 'function' &&
                typeof o.catch === 'function') {
              o.then((x) => handleCallback(null, x))
                  .catch(e => handleCallback(e || 'Rejected'));
              return;
            }
          }
          handleCallback(null, o);
        } catch (e) {
          handleCallback(e);
        }
      };
      if (first)
        this._queue.unshift(executor);
      else this._queue.push(executor);
      setImmediate(() => this._next());
    });
  }

  /**
   * Executes next task
   * @private
   */
  _next() {
    if (this._taskRunning || this.paused)
      return;
    this._taskRunning = this._queue.shift();
    if (this._taskRunning)
      this._taskRunning();
  }

  /**
   *
   */
  clear() {
    this._queue = new DoublyLinked();
  }
}

/**
 * Expose `TaskQueue`.
 */

module.exports = TaskQueue;
